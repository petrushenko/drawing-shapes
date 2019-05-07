using PluginInterface;

namespace Plugins
{
    internal class CircleCreator : IShapeCreatorPlugin
    {
        public IShapePlugin GetShape()
        {
            return new Circle();
        }
    }
}