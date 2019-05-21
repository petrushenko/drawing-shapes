using PluginInterface;

namespace Plugins
{
    internal class SquareCreator : IShapeCreator
    {
        public IShape GetShape()
        {
            return new Square();
        }
    }
}