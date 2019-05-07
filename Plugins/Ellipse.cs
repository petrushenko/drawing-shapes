using System;
using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Ellipse : Rectangle
    {
        public override string ButtonName => "Ellipse";

        public override IShapeCreatorPlugin ButtonTag => new EllipseCreator();

        public override void Draw(Graphics graphics)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graphics.DrawEllipse(pen, Point1.X, Point1.Y, GetWidth(), GetHeight());
            }
        }
    }
}
