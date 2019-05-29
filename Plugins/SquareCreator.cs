using PluginInterface;

namespace Plugins
{
    internal class SquareCreator : IShapeCreator
    {

        public IShapeCreator ButtonTag => new SquareCreator();

        public string ButtonName => "Square";
        public IShape GetShape()
        {
            return new Square();
        }
    }
}