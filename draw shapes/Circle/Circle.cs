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
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawEllipse(pen, this.Point1.X, this.Point1.Y, GetHeight(), GetHeight());
            pen.Dispose();
        }
    }
}
