using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SystemForAll.Point
{
    public delegate float Pointer(float x, float y, float z);

    enum PointState
    { Created, Trashed, Deleted }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int M { get; set; }
        public PointState PointState { get; set; }

        public Point(int xVal, int yVal, int zVal, int mVal)
        {
            X = xVal;
            Y = yVal;
            Z = zVal;
            M = mVal;
        }

        public Point(PointState ptState)
        {
            PointState = ptState;
        }



        public Point()
          : this(PointState.Created) { }

        public void DisplayStats()
        {
            var dialog = new MessageDialog(X.ToString(), Y.ToString());
        }

        public static Point operator +(Point p1, int change)
        {
            return new Point(p1.X + change, p1.Y + change, p1.Z + change, p1.M + change);
        }
        public static Point operator +(int change, Point p1)
        {
            return new Point(p1.X + change, p1.Y + change, p1.Z + change, p1.M + change);
        }
    }
}
