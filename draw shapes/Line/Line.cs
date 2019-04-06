using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace draw_shapes
{
    [DataContract]
    class Line : Shape
    {
        public override void Draw(Graphics graph)
        {
            using (Pen pen = new Pen(Color.Black, 3))
            {
                graph.DrawLine(pen, Point1, Point2);
            }
        }
    }
}
