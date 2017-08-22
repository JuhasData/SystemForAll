using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForAll.Point
{
    public struct PointStruct<T>
    {
        //Add User information
        private User user;
        private Session session;
        private Location location;
        private Global global;
        private Entity entity;

                // Generic state date.
        private T xPos;
        private T yPos;
        private T zPos;

        // Generic constructor.
        public PointStruct(T xVal, T yVal, T zVal, User userVal, Session sessionVal, Location locationVal, Global globalVal, Entity entityVal)
        {
            xPos = xVal;
            yPos = yVal;
            zPos = zVal;
            user = userVal;
            session = sessionVal;
            location = locationVal;
            global = globalVal;
            entity = entityVal;
        }

        // Generic properties.
        public User userProp 
        { 
           get { return user; }
           set { user = value; } 
        }

        public Session sessionProp 
        {
             get {return session; }
             set { session = value;} 
        }
        public Location locationProp 
        { 
            get { return location; }
            set; { location = value; }
        }
        public Global globalProp 
        { 
            get { return global; }
            set { global = value; }
        }

        public Entity entityProp 
        { 
            get { return entity;} 
            set { entity = value;} 
        }

        public T X
        {
            get { return xPos; }
            set { xPos = value; }

        }

        public T Y
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public T Z
        {
            get { return zPos; }
            set { zPos = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}]", xPos, yPos, zPos, user, session, location, global, entity);
        }

        // Reset fields to the default value of the
        // type parameter.
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
            zPos = default(T);
            user = default(null);
            session = default(null)
            location = default(null);
            global = default(null);
            entity = default(null);
        }
    }
}
