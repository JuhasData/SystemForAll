using System;
using System.Collections.Generic;
using System.Text;

namespace WorldSystem
{
    class Addline_Densification
    {
        //public void AddLine(double latitude, double longitude, double? z, double? m)
        //{
        //    // Transform from geodetic coordinates to a unit vector
        //    Vector3 endPoint = Util.SphericalDegToCartesian(latitude, longitude);
        //    double angle = endPoint.Angle(_startPoint);
        //    if (angle > MinAngle)
        //    {
        //        // _startPoint and endPoint are the unit vectors that correspond to the input
        //        // start and end points. In their 3D space we operate in a local coordinate system
        //        // where _startPoint is the x axis and the xy plane contains endPoint. Every
        //        // point is now generated from the previous one by a fixed rotation in the local
        //        // xy plane, and converted back to geodetic coordinates.
        //        // Construct the local z and y axes
        //        Vector3 zAxis = (_startPoint + endPoint).CrossProduct(_startPoint - endPoint).Unitize();
        //        Vector3 yAxis = (_startPoint).CrossProduct(zAxis);
        //        // Calculate how many points are required
        //        int count = Convert.ToInt32(Math.Ceiling(angle / Util.ToRadians(_angle)));
        //        // Scale the angle so that points are equally placed
        //        double exactAngle = angle / count;
        //        double cosine = Math.Cos(exactAngle);
        //        double sine = Math.Sin(exactAngle);
        //        // Set the first x and y points in the local coordinate system
        //        double x = cosine;
        //        double y = sine;
        //        for (int i = 0; i < count - 1; i++)
        //        {
        //            Vector3 newPoint = (_startPoint * x + yAxis * y).Unitize();
        //            // Add the point
        //            _sink.AddLine(Util.LatitudeDeg(newPoint), Util.LongitudeDeg(newPoint), null, null);
        //            // Rotate to get next point
        //            double r = x * cosine - y * sine;
        //            y = x * sine + y * cosine;
        //            x = r;
        //        }
        //    }
        //    _sink.AddLine(latitude, longitude, z, m);
        //    // Remember last point we added
        //    _startPoint = endPoint;
        //}
    }
}
