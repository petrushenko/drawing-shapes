using System.Drawing;
using System.Runtime.Serialization;

namespace draw_shapes
{
    [DataContract]
    class Triangle : Line
    {
        [DataMember]
        public Point[] Points = new Point[3];

        private void DistributeCoords()
        {
            int X1 = (Point1.X + Point2.X) / 2;
            int Y1 = (Point1.Y + Point2.Y) / 2;
            int X2 = Point2.X;
            int Y2 = Point2.Y;
            int X3 = Point1.X;
            int Y3 = Point2.Y;

            Points[0] = new Point(X1, Y1);
            Points[1] = new Point(X2, Y2);
            Points[2] = new Point(X3, Y3);
        }

        public override void Draw(Graphics graph)
        {
            this.DistributeCoords();
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawPolygon(pen, Points);
            pen.Dispose();
        }

    }
}
