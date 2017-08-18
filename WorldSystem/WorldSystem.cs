using Microsoft.SqlServer.Types;
using ProjNet.CoordinateSystems.Transformations;

namespace WorldSystems
{

    class WorldSystem : IGeographySink110
    {
        private readonly ICoordinateTransformation _trans;
        private readonly IGeometrySink110 _sink;


        public WorldSystem(ICoordinateTransformation trans, IGeometrySink110 sink)
        {
            _trans = trans;
            _sink = sink;
        }

        public void BeginGeography(OpenGisGeographyType type)
        {
            // Begin creating a new geometry of the type requested
            _sink.BeginGeometry((OpenGisGeometryType)type);
        }
        public void BeginFigure(double latitude, double longitude, double? z, double? m)
        {
            // Use ProjNET Transform() method to project lat,lng coordinates to x,y
            double[] startPoint = _trans.MathTransform.Transform(new double[]
            { longitude, latitude });
            // Begin a new geometry figure at corresponding x,y coordinates
            _sink.BeginFigure(startPoint[0], startPoint[1], z, m);
        }
        public void AddLine(double latitude, double longitude, double? z, double? m)
        {
            // Use ProjNET to transform end point of the line segment being added
            double[] toPoint = _trans.MathTransform.Transform(new double[]
            { longitude, latitude });
            // Add this line to the geometry
            _sink.AddLine(toPoint[0], toPoint[1], z, m);
        }
        public void AddCircularArc(double latitude1, double longitude1, double? z1, double? m1,
        double latitude2, double longitude2, double? z2, double? m2
        )
        {
            // Transform both the anchor point and destination of the arc segment
            double[] anchorPoint = _trans.MathTransform.Transform(new double[]
            { longitude1, latitude1 });
            double[] toPoint = _trans.MathTransform.Transform(new double[]
            { longitude2, latitude2 });
            // Add this arc to the geometry
            _sink.AddCircularArc(anchorPoint[0], anchorPoint[1], z1, m1,
            toPoint[0], toPoint[1], z2, m2);
        }
        public void EndFigure()
        {
            _sink.EndFigure();
        }
        public void EndGeography()
        {
            _sink.EndGeometry();
        }
        public void SetSrid(int srid)
        {
            // Just pass through
        }
    }
}
