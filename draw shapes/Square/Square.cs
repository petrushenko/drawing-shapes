using System;
using System.Drawing;

namespace draw_shapes
{
    class Square : Rectangle
    {
        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawRectangle(pen, Point1.X, Point1.Y, Height, Height);
            pen.Dispose();
        }
    }
}
