using PluginInterface;

namespace Plugins
{
    public class EllipseCreator : IShapeCreator
    {
        public IShape GetShape()
        {
            return new Ellipse();
        }
    }
}
