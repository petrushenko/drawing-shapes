using PluginInterface;

namespace Plugins
{
    public class TriangleCreator : IShapeCreator
    {
        public IShape GetShape()
        {
            return new Triangle();
        }
    }
}
