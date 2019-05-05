namespace draw_shapes
{
    class CircleCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Circle();
        }
    }
}
