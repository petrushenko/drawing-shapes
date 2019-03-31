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
            Pen pen = new Pen(Color.Black, 3);
            graph.DrawLine(pen, this.Point1, this.Point2);
            pen.Dispose();
        }
    }
}
