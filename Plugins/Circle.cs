using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Plugins
{
    public class Circle : Ellipse
    {

        public override string ButtonName => "Circle";

        public override IShapeCreatorPlugin ButtonTag => new CircleCreator();

        public override void Draw(Graphics graphics)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graphics.DrawEllipse(pen, Point1.X, Point1.Y, GetHeight(), GetHeight());
            }
        }
    }
}
