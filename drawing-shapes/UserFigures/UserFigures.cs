using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace draw_shapes
{
    public class UserFigure : ICloneable
    {
        public List<IShape> Shapes = new List<IShape>();

        public UserFigure(List<IShape> shapes, Point p1, Point p2)
        {
            foreach (IShape shape in shapes)
            {
                Shapes.Add(shape);
            }
            Point1 = p1;
            Point2 = p2;
        }

        Point Point1 { get; set; }
        Point Point2 { get; set; }

        public virtual void RebuildCoords(Point p1, Point p2)
        {
            foreach (IShape shape in Shapes)
            {             
                int newX1 = p1.X + (shape.Point1.X - Point1.X) * (p2.X - p1.X) / (Point2.X - Point1.X);
                int newY1 = p1.Y + (shape.Point1.Y - Point1.Y) * (p2.Y - p1.Y) / (Point2.Y - Point1.Y);
                Point newPoint1 = new Point(newX1, newY1);
                int newX2 = newPoint1.X + (shape.Point2.X - shape.Point1.X) * (p2.X - p1.X) / (Point2.X - Point1.X);
                int newY2 = newPoint1.Y + (shape.Point2.Y - shape.Point1.Y) * (p2.Y - p1.Y) / (Point2.Y - Point1.Y);
                Point newPoint2 = new Point(newX2, newY2);
                shape.Point1 = newPoint1;
                shape.Point2 = newPoint2;
            }
        }

        public object Clone()
        {
            return new UserFigure(this.Shapes, Point1, Point2);
        }
    }
}
