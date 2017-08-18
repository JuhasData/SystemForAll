using System;
using System.Data.SqlTypes;
using System.Data.SqlClient; // Required for context connection
using Microsoft.SqlServer.Server; // SqlFunction Decoration
using Microsoft.SqlServer.Types; // SqlGeometry and SqlGeography
using ProjNet.CoordinateSystems; // ProjNET coordinate systems
using ProjNet.CoordinateSystems.Transformations; // ProjNET transformation functions
using ProjNet.Converters.WellKnownText; //ProjNET WKT functions

namespace WorldSystems
{
    public partial class SystemForAll
    {
        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static SqlGeometry GeographyToGeometry(SqlGeography geog, SqlInt32 toSRID, string test)
        {
            // Use the context connection to the SQL Server instance on which this is executed
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                // Open the connection
                conn.Open();
                // Retrieve the parameters of the source spatial reference system
                SqlCommand cmd = new SqlCommand("SELECT well_known_text FROM prospatial_reference_systems WHERE spatial_reference_id = @srid", conn);
                cmd.Parameters.Add(new SqlParameter("srid", geog.STSrid));
                object fromResult = cmd.ExecuteScalar();
                // Check that details of the source SRID have been found
                if (fromResult is System.DBNull || fromResult == null)
                { return null; }
                // Retrieve the WKT
                String fromWKT = Convert.ToString(fromResult);
                // Create the source coordinate system from WKT
                ICoordinateSystem fromCS = CoordinateSystemWktReader.Parse(fromWKT) as
                ICoordinateSystem;
                // Retrieve the parameters of the destination spatial reference system
                cmd.Parameters["srid"].Value = toSRID;
                object toResult = cmd.ExecuteScalar();
                // Check that details of the destination SRID have been found
                if (toResult is System.DBNull || toResult == null)
                { return null; }
                // Execute the command and retrieve the WKT
                String toWKT = Convert.ToString(toResult);
                // Clean up
                cmd.Dispose();
                // Create the destination coordinate system from WKT
                ICoordinateSystem toCS = CoordinateSystemWktReader.Parse(toWKT) as
                ICoordinateSystem;
                // Create a CoordinateTransformationFactory instance
                CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
                // Create the transformation between the specified coordinate systems
                ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(fromCS, toCS);
                // Create a geometry instance to be populated by the sink
                SqlGeometryBuilder b = new SqlGeometryBuilder();
                // Set the SRID to match the destination SRID
                b.SetSrid((int)toSRID);
                // Create a sink for the transformation and plug it in to the builder
                WorldSystem w = new WorldSystem(trans, b);
                // Populate the sink with the supplied geography instance
                geog.Populate(w);
                // Return the transformed geometry instance
                return b.ConstructedGeometry;
            }
           
        }
    }
}
