using PluginInterface;

namespace Plugins
{
    public class TriangleCreator : IShapeCreator
    {
        public string ButtonName => "Triangle";

        public IShapeCreator ButtonTag => new TriangleCreator();

        public IShape GetShape()
        {
            return new Triangle();
        }
    }
}
