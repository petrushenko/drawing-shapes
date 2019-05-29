using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Line : IShape
    {        
        public IShape Clone()
        {
            Line line = new Line();
            line.Point1 = Point1;
            line.Point2 = Point2;
            return line;
        }
        public virtual Point Point1 { get; set; }
        public virtual Point Point2 { get; set; }
        public virtual void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graphics.DrawLine(pen, Point1, Point2);
            }
        }
    }
}
