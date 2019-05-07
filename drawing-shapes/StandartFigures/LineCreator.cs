using PluginInterface;

namespace Plugins
{
    public class LineCreator : IShapeCreatorPlugin
    {
        public virtual IShapePlugin GetShape()
        {
            return new Line();
        }
    }
}
