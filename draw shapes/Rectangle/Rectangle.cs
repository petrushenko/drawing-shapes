using System;
using System.Drawing;

namespace draw_shapes
{
    class Rectangle : Shape
    {
        public int Width { get { return Math.Abs(Point2.X - Point1.X); } }
        public int Height { get { return Math.Abs(Point2.Y - Point1.Y); } }

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
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawRectangle(pen, this.Point1.X, this.Point1.Y, Width, Height);
            pen.Dispose();
        }
    }
}
