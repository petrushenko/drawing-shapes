﻿using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Triangle : IShape
    {

        public IShape Clone()
        {
            Triangle triangle = new Triangle();
            triangle.Point1 = Point1;
            triangle.Point2 = Point2;
            return triangle;
        }

        public Point[] Points = new Point[3];

        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        private void DistributeCoords()
        {
            int X1 = (Point1.X + Point2.X) / 2;
            int Y1 = (Point1.Y + Point2.Y) / 2;
            int X2 = Point2.X;
            int Y2 = Point2.Y;
            int X3 = Point1.X;
            int Y3 = Point2.Y;

            Points[0] = new Point(X1, Y1);
            Points[1] = new Point(X2, Y2);
            Points[2] = new Point(X3, Y3);
        }

        public void Draw(Graphics graph)
        {
            DistributeCoords();

            using (Pen pen = new Pen(Color.Black, 3))
            {
                graph.DrawPolygon(pen, Points);
            }
        }
    }
}
