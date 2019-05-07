using System;
using PluginInterface;

namespace Plugins
{
    public class RectangleCreator : IShapeCreatorPlugin
    {
        public virtual IShapePlugin GetShape()
        {
            return new Rectangle();   
        }
    }
}
