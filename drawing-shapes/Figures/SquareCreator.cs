using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draw_shapes
{
    class SquareCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Square();
        }
    }
}
