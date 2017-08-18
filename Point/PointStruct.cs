using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForAll.Point
{
    public struct PointStruct<T>
    {
        // Generic state date.
        private T xPos;
        private T yPos;
        private T zPos;

        // Generic constructor.
        public PointStruct(T xVal, T yVal, T zVal)
        {
            xPos = xVal;
            yPos = yVal;
            zPos = zVal;
        }

        // Generic properties.
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
            return string.Format("[{0}, {1}, {2}]", xPos, yPos, zPos);
        }

        // Reset fields to the default value of the
        // type parameter.
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
            zPos = default(T);
        }
    }
}
