using System;
using PluginInterface;

namespace Plugins
{
    public class RectangleCreator : IShapeCreator
    {
        public virtual IShapeCreator ButtonTag => new RectangleCreator();
        public virtual string ButtonName => "Rectangle";
        public virtual IShape GetShape()
        {
            return new Rectangle();   
        }
    }
}
