using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SystemForAll.Session
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SessionService : ISessionService
    {
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public WorldSystemEntity GetWorldSystem(int spatialID)
        {
            WorldSystemModel context = new WorldSystemModel();
            var worldSystemData = (from d in context.WorldSystems where d.Spatial_Reference_Id == spatialID select d).FirstOrDefault();
            if (worldSystemData != null)
                return TranslateWorldSystemEntitiesToSession(worldSystemData);
            else
                throw new Exception("Could not load the WorldSystem");
        }

        private WorldSystemEntity TranslateWorldSystemEntitiesToSession(WorldSystemEntity worldSystemData)
        {
            WorldSystemEntity worldSystem = new WorldSystemEntity();
            worldSystem.Spatial_Reference_Id = worldSystemData.Spatial_Reference_Id;
            worldSystem.Well_Known_Text = worldSystemData.Well_Known_Text;
            worldSystem.Coordinate_System = worldSystemData.Coordinate_System;
            worldSystem.Datum = worldSystemData.Datum;
            worldSystem.Prime_Meridan = worldSystemData.Prime_Meridan;
            worldSystem.Projection = worldSystemData.Projection;
            worldSystem.Unit_of_Measure = worldSystemData.Unit_of_Measure;
            worldSystem.Unit_Conversion_Factor = worldSystemData.Unit_Conversion_Factor;
            worldSystem.Authority_Name = worldSystemData.Authority_Name;
            return worldSystem;
        }

        public LocationEntity GetLocation(int id)
        {
            WorldSystemModel context = new WorldSystemModel();
            var locationData = (from d in context.Locations where d.Id == id select d).FirstOrDefault();
            if (locationData != null)
                return TranslateLocationsEntitiesToSession(locationData);
            else
                throw new Exception("Could not load the LocationEntity");
        }

        private LocationEntity TranslateLocationsEntitiesToSession(LocationEntity locationData)
        {
            LocationEntity location = new LocationEntity();
            location.Id = locationData.Id;
            location.Latitude = locationData.Latitude;
            location.Longitude = locationData.Longitude;
            location.Name = locationData.Name;
            location.Geo = locationData.Geo;
            location.Globals = locationData.Globals;
            location.Session = locationData.Session;
            location.Location1 = locationData.Location1;
            location.Type = locationData.Type;
            return location;
        }

        public GlobalEntity GetGlobal(int id)
        {
            WorldSystemModel context = new WorldSystemModel();
            var globalData = (from d in context.Globals where d.Id == id select d).FirstOrDefault();
            if (globalData != null)
                return TranslateGlobalEntitiesToSession(globalData);
            else
                throw new Exception("Could Not Load GlobalEntity");

        }

        private GlobalEntity TranslateGlobalEntitiesToSession(GlobalEntity globalData)
        {
            GlobalEntity global = new GlobalEntity();
            global.Id = globalData.Id;
            global.Name = globalData.Name;
            global.User = globalData.User;
            global.Session = globalData.Session;
            global.Location = globalData.Location;
            global.Unit = globalData.Unit;
            global.Geometry_Type = globalData.Geometry_Type;
            global.Method = globalData.Method;
            global.Height = globalData.Height;
            global.Width = globalData.Width;
            global.Weight = globalData.Weight;
            global.Dimension = globalData.Dimension;
            global.Coordinate_Dimension = globalData.Coordinate_Dimension;
            global.Spatial_Dimension = globalData.Spatial_Dimension;
            global.Envelope = globalData.Envelope;
            global.Point0 = globalData.Point0;
            global.Point1 = globalData.Point1;
            global.Point2 = globalData.Point2;
            global.Point3 = globalData.Point3;
            global.Point4 = globalData.Point4;
            global.Point5 = globalData.Point5;
            global.Point6 = globalData.Point6;
            global.Point7 = globalData.Point7;
            global.Point8 = globalData.Point8;
            global.Point9 = globalData.Point9;
            global.Point10 = globalData.Point10;
            global.Point11 = globalData.Point11;
            global.Point12 = globalData.Point12;
            global.Point13 = globalData.Point13;
            global.Point14 = globalData.Point14;
            global.Point15 = globalData.Point15;
            global.Point16 = globalData.Point16;
            global.Point17 = globalData.Point17;
            global.Point18 = globalData.Point18;
            global.Point19 = globalData.Point19;
            global.Point20 = globalData.Point20;
            global.Point21 = globalData.Point21;
            global.Point22 = globalData.Point22;
            global.Point23 = globalData.Point23;
            global.Point24 = globalData.Point24;
            global.Point25 = globalData.Point25;
            global.Point26 = globalData.Point26;

            return global;
        }
    }
}



