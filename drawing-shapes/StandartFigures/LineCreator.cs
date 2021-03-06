﻿using PluginInterface;

namespace draw_shapes
{
    public class LineCreator : IShapeCreator
    {
        public virtual string ButtonName => "Line";
        public virtual IShapeCreator ButtonTag => new LineCreator();
        public virtual IShape GetShape()
        {
            return new Line();
        }
    }
}
