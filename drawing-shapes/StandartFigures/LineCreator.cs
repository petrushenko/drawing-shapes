using PluginInterface;

namespace Plugins
{
    public class LineCreator : IShapeCreator
    {
        public virtual IShape GetShape()
        {
            return new Line();
        }
    }
}
