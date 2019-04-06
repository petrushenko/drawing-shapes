using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace draw_shapes
{
    [DataContract]
    class Square : Rectangle
    {
        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graph.DrawRectangle(pen, Point1.X, Point1.Y, GetHeight(), GetHeight());
            }
        }
    }
}
