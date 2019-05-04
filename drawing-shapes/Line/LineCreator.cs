namespace draw_shapes
{
    class LineCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Line();
        }
    }
}
