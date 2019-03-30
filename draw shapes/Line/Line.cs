using System.Drawing;

namespace draw_shapes
{
    class Line : Shape
    {
        public override void Draw(Graphics graph)
        {
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawLine(pen, this.Point1, this.Point2);
            pen.Dispose();
        }
    }
}
