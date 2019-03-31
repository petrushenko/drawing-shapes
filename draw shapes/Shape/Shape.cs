using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace draw_shapes
{
    [DataContract, KnownType(typeof(Circle)), KnownType(typeof(Triangle)), KnownType(typeof(Ellipse)),
        KnownType(typeof(Line)), KnownType(typeof(Square)), KnownType(typeof(Rectangle))]
    abstract class Shape
    {
        [DataMember (Name = "Point1")]
        public Point Point1 { get; set; }

        [DataMember (Name = "Point2")]
        public Point Point2 { get; set; }

        public abstract void Draw(Graphics graph);         
    }
}
