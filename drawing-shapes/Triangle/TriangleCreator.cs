namespace draw_shapes
{
    class TriangleCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Triangle();
        }
    }
}
