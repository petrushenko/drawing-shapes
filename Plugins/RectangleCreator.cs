using System;
using PluginInterface;

namespace Plugins
{
    public class RectangleCreator : LineCreator
    {
        public override IShapePlugin GetShape()
        {
            return new Rectangle();   
        }
    }
}
