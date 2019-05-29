using PluginInterface;
using System.Drawing;

namespace Plugins
{
    public class Square : Rectangle
    {
        public override IShape Clone()
        {
            Square square = new Square();
            square.Point1 = Point1;
            square.Point2 = Point2;
            return square;
        }

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
