using System.Drawing;

namespace draw_shapes
{
    abstract class Shape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public abstract void Draw(Graphics graph);         
    }
}
