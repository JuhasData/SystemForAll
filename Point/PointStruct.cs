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
        private long user;
        private long session;
        private long location;
        private long global;
        private long entity;

                // Generic state date.
        private T xPos;
        private T yPos;
        private T zPos;

        // Generic constructor.
        public PointStruct(T xVal, T yVal, T zVal, long userVal, long sessionVal, long locationVal, long globalVal, long entityVal)
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
        public long userProp 
        { 
           get { return user; }
           set { user = value; } 
        }

        public long sessionProp 
        {
             get {return session; }
             set { session = value;} 
        }
        public long locationProp 
        { 
            get { return location; }
            set { location = value; }
        }
        public long globalProp 
        { 
            get { return global; }
            set { global = value; }
        }

        public long entityProp 
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
            user = default(long);
            session = default(long);
            location = default(long);
            global = default(long);
            entity = default(long);
        }
    }
}
