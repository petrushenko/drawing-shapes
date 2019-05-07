using PluginInterface;

namespace Plugins
{
    public class EllipseCreator : IShapeCreatorPlugin
    {
        public IShapePlugin GetShape()
        {
            return new Ellipse();
        }
    }
}
