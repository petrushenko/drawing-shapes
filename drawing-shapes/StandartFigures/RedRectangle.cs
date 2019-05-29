using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draw_shapes
{
    public class RedRectangle : IShape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public IShape Clone()
        {
            RedRectangle redRectangle = new RedRectangle();
            redRectangle.Point1 = Point1;
            redRectangle.Point2 = Point2;
            return redRectangle;
        }
        //заменить
        public void CoordsSwap()
        {
            int X1 = Point1.X, X2 = Point2.X, Y1 = Point1.Y, Y2 = Point2.Y;
            if (X1 > X2)
            {
                int tmpCoord = X1;
                X1 = X2;
                X2 = tmpCoord;
            }
            if (Y1 > Y2)
            {
                int tmpCoord = Y1;
                Y1 = Y2;
                Y2 = tmpCoord;
            }
            Point pt1 = new Point(X1, Y1);
            Point1 = pt1;
            Point pt2 = new Point(X2, Y2);
            Point2 = pt2;
        }
        public int GetWidth()
        {
            return Math.Abs(Point2.X - Point1.X);
        }

        public int GetHeight()
        {
            return Math.Abs(Point2.Y - Point1.Y);
        }

        public void Draw(Graphics graphics)
        {
            CoordsSwap();
            using (Pen pen = new Pen(Color.Red, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(pen, Point1.X, Point1.Y, GetWidth(), GetHeight());
            }
        }
    }
}
