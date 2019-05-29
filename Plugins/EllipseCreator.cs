using PluginInterface;

namespace Plugins
{
    public class EllipseCreator : IShapeCreator
    {
        public string ButtonName => "Ellipse";
        public IShapeCreator ButtonTag => new EllipseCreator();
        public IShape GetShape()
        {
            return new Ellipse();
        }
    }
}
