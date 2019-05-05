using System;
using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Rectangle : Line, IShapePlugin
    {
        public override IShapeCreatorPlugin ButtonTag => new RectangleCreator();
        public override string ButtonName => "Rectangle";
        public int GetWidth()
        {
            return Math.Abs(Point2.X - Point1.X);
        }

        public int GetHeight()
        {
            return Math.Abs(Point2.Y - Point1.Y);
        }

        public void CoordsSwap()
        {
            int X1 = Point1.X, X2 = Point2.X, Y1 = Point1.Y, Y2 = Point2.Y;
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
            Point1 = pt1;
            Point pt2 = new Point(X2, Y2);
            Point2 = pt2;
        }

        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graph.DrawRectangle(pen, Point1.X, Point1.Y, GetWidth(), GetHeight());
            }
        }
    }
}
