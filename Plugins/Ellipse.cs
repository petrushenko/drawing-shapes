using System;
using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Ellipse : Rectangle
    {
        public override IShape Clone()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Point1 = Point1;
            ellipse.Point2 = Point2;
            return ellipse;
        }
        public override string ButtonName => "Ellipse";

        public override IShapeCreator ButtonTag => new EllipseCreator();

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
