using PluginInterface;

namespace Plugins
{
    internal class CircleCreator : IShapeCreator
    {
        public IShape GetShape()
        {
            return new Circle();
        }
    }
}