using PluginInterface;

namespace Plugins
{
    public class TriangleCreator : IShapeCreatorPlugin
    {
        public IShapePlugin GetShape()
        {
            return new Triangle();
        }
    }
}
