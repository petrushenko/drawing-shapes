using PluginInterface;

namespace Plugins
{
    internal class SquareCreator : IShapeCreatorPlugin
    {
        public IShapePlugin GetShape()
        {
            return new Square();
        }
    }
}