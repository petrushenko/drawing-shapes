using System.Drawing;

namespace draw_shapes
{
    public static class CoordsMaster
    {

        public static Point[] SwapCoords(Point[] points)
        {
            Point point1 = new Point(0,0);
            Point point2 = new Point(0,0);
            if (points[0] != null && points[1] != null)
            {
                point1 = points[0];
                point2 = points[1];
            }
            else
            {
                throw new System.Exception("");
            }
            int X1 = point1.X, X2 = point2.X, Y1 = point1.Y, Y2 = point2.Y;
            if (X1 > X2)
            {
                int tmpCoord = X1;
                X1 = X2;
                X2 = tmpCoord;
            }
            if (Y1 > Y2)
            {
                int tmpCoord = Y1;
                Y1 = Y2;
                Y2 = tmpCoord;
            }
            Point pt1 = new Point(X1, Y1);
            point1 = pt1;
            Point pt2 = new Point(X2, Y2);
            point2 = pt2;
            return new[] { point1, point2 };
        }

    }
}
