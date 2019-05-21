using System;
using PluginInterface;

namespace Plugins
{
    public class RectangleCreator : IShapeCreator
    {
        public virtual IShape GetShape()
        {
            return new Rectangle();   
        }
    }
}
