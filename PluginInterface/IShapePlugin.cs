using System.Drawing;
using System.Runtime.Serialization;

namespace PluginInterface
{
    public interface IShape
    {
        Point Point1 { get; set; }
        Point Point2 { get; set; }
        void Draw(Graphics graphics);
        IShape Clone();
    }
}
