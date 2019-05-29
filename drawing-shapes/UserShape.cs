using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace draw_shapes
{
    public class UserShape
    {
        public List<IShape> Shapes = new List<IShape>();
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public UserShape(List<IShape> shapes, Point p1, Point p2)
        {
            Shapes = shapes;
            Point1 = p1;
            Point2 = p2;
        }

        private void RebuildShapesCoords(Point p1, Point p2)
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
        
        public void CopyToListShapes(List<IShape> shapesList, Point p1, Point p2)
        {
            if (shapesList == null)
            {
                return;
            }
            RebuildShapesCoords(p1, p2);
            foreach (IShape shape in Shapes)
            {
                shapesList.Add(shape);
            }
        }
    }
}
