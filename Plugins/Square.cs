using PluginInterface;
using System.Drawing;

namespace Plugins
{
    public class Square : Rectangle
    {
        public override IShapeCreatorPlugin ButtonTag => new SquareCreator();

        public override string ButtonName => "Square";

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
