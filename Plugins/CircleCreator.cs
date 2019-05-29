using PluginInterface;

namespace Plugins
{
    internal class CircleCreator : IShapeCreator
    {
        public string ButtonName => "Circle";
        public IShapeCreator ButtonTag => new CircleCreator();
        public IShape GetShape()
        {
            return new Circle();
        }
    }
}