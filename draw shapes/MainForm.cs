using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draw_shapes
{
    public partial class FrmMain : Form
    {
        private bool MousePressed {get;set;}

        private List<Shape> Shapes = new List<Shape>();

        private Point Point1 { get; set; }

        private Point Point2 { get; set; }

        private ShapeCreator CurrentShapeCreator { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void PnlDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentShapeCreator != null)
            {
                Point1 = new Point(e.X, e.Y);
                MousePressed = true;
            }
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentShapeCreator != null)
            {
                Point2 = new Point(e.X, e.Y);
                Shape CurrShape = CurrentShapeCreator.GetInstance();
                CurrShape.Point1 = Point1;
                CurrShape.Point2 = Point2;
                Shapes.Add(CurrShape);
                pnlDrawingArea.Invalidate();
            }

        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new LineCreator();
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new RectangleCreator();
        }

        private void PnlDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics drawingArea = pnlDrawingArea.CreateGraphics();
            foreach (Shape shape in Shapes)
            {
                shape.Draw(drawingArea);
            }
            drawingArea.Dispose();
        }

        private void Clear()
        {
            Shapes.Clear();
            pnlDrawingArea.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new SquareCreator();
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {

            }
        }
    }
}
