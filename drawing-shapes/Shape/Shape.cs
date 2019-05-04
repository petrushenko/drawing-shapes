using System.Drawing;
using System.Runtime.Serialization;

namespace draw_shapes
{
    [DataContract]
    abstract class Shape
    {
        [DataMember]
        public Point Point1 { get; set; }

        [DataMember]
        public Point Point2 { get; set; }

        public abstract void Draw(Graphics graph);         
    }
}
