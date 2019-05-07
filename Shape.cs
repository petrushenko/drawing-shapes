using System.Drawing;
using PluginInterface;

namespace draw_shapes
{
    abstract class Shape : IShapePlugin
    {
        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public string ButtonName => throw new System.NotImplementedException();

        public IShapeCreatorPlugin ButtonTag => throw new System.NotImplementedException();

        public abstract void Draw(Graphics graph);

        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}
