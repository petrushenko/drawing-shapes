using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
