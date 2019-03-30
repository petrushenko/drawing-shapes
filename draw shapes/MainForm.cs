using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace draw_shapes
{
    public partial class FrmMain : Form
    {
        private Shape TmpShape { get; set; }

        private readonly List<Shape> Shapes = new List<Shape>();

        private Point FirstPoint { get; set; }

        private ShapeCreator CurrentShapeCreator { get; set; }

        private Bitmap BufferedPicture { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            BufferedPicture = new Bitmap(pnlDrawingArea.Width, pnlDrawingArea.Height);
        }

        private void DoDrawing()
        {
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            foreach (Shape shape in Shapes)
            {
                shape.Draw(drawingArea);
            }
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
        }

        private void PnlDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentShapeCreator != null)
            {
                FirstPoint = new Point(e.X, e.Y);
                TmpShape = CurrentShapeCreator.GetInstance();
            }
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentShapeCreator != null)
            {
                Shape currShape = CurrentShapeCreator.GetInstance();
                currShape.Point1 = FirstPoint;
                currShape.Point2 = new Point(e.X, e.Y);
                Shapes.Add(currShape);
                TmpShape = null;
                DoDrawing();
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

        private void ClearScreen()
        {
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            drawingArea.Clear(Color.White);
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
            DoDrawing();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            ClearScreen();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new SquareCreator();
        }

        private void BtnCircle_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new CircleCreator();
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new EllipseCreator();
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            CurrentShapeCreator = new TriangleCreator();
        }

        private void PnlDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CurrentShapeCreator != null)
            {
                ClearScreen();
                TmpShape.Point1 = FirstPoint;
                TmpShape.Point2 = new Point(e.X, e.Y);
                Shapes.Add(TmpShape);
                DoDrawing();
                Shapes.Remove(TmpShape);
            }
        }
    }
}
