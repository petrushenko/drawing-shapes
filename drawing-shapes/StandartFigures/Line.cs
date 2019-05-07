using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Line : IShapePlugin
    {        
        public virtual Point Point1 { get; set; }
        public virtual Point Point2 { get; set; }
        public virtual string ButtonName => "Line";
        public virtual IShapeCreatorPlugin ButtonTag => new LineCreator();
        public virtual void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graphics.DrawLine(pen, Point1, Point2);
            }
        }
    }
}
