using Newtonsoft.Json;
using PluginInterface;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace draw_shapes
{
    public class UserShapeCreator
    {
        public List<IShape> Shapes = new List<IShape>();
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public string Name { get; set; }

        public UserShapeCreator(List<IShape> shapes, Point p1, Point p2, string name)
        {
            foreach (IShape shape in shapes)
            {
                //сделать проверку на валидные координаты
                Point[] sortPoints = CoordsMaster.SwapCoords(new[] { p1, p2 });
                p1 = sortPoints[0];
                p2 = sortPoints[1];
                //if (shape.Point1.X >= p1.X && shape.Point2.X <= p2.X)
                //{
                //    if (shape.Point1.Y >= p1.Y && shape.Point2.Y <= p2.Y)
                //    {
                        Shapes.Add(shape.Clone());
                //    }
                //}
            }
            Name = name;
            Point1 = p1;
            Point2 = p2;
        }

        public UserShape GetUserShape()
        {
            List<IShape> newShapes = new List<IShape>();
            foreach (IShape shape in Shapes)
            {
                if (shape.Point1.X >= Point1.X && shape.Point2.X <= Point2.X)
                {
                    if (shape.Point1.Y >= Point1.Y && shape.Point2.Y <= Point2.Y)
                    {
                        newShapes.Add(shape.Clone());
                    }
                }
            }
            Point[] sortPoints = CoordsMaster.SwapCoords(new[] { Point1, Point2 });
            return new UserShape(newShapes, sortPoints[0], sortPoints[1]);
        }
    }
}
