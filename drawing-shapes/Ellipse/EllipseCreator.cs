namespace draw_shapes
{
    class EllipseCreator : ShapeCreator
    {
        public override Shape GetInstance()
        {
            return new Ellipse();
        }
    }
}
