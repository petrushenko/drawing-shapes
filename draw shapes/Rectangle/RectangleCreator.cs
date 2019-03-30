namespace draw_shapes
{
    class RectangleCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Rectangle();
        }
    }
}
