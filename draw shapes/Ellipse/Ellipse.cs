using System.Drawing;

namespace draw_shapes
{
    class Ellipse : Rectangle
    {
        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawEllipse(pen, Point1.X, Point1.Y, Width, Height);
            pen.Dispose();
        }

    }
}
