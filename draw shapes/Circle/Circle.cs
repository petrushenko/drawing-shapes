using System.Drawing;

namespace draw_shapes
{
    class Circle : Square
    {
        public override void Draw(Graphics graph)
        {
            CoordsSwap();
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawEllipse(pen, this.Point1.X, this.Point1.Y, Height, Height);
            pen.Dispose();
        }
    }
}
