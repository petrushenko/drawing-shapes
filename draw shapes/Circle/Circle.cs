using System.Drawing;
using System.Runtime.Serialization;

namespace draw_shapes
{
    [DataContract]
    class Circle : Square
    {
        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graph.DrawEllipse(pen, Point1.X, Point1.Y, GetHeight(), GetHeight());
            }
        }
    }
}
