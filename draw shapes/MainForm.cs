using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace draw_shapes
{
    public partial class FrmMain : Form
    {
        private Shape TmpShape { get; set; }

        private List<Shape> Shapes = new List<Shape>();

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
            ClearScreen();
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

        private void ClearScreen()
        {
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            drawingArea.Clear(Color.White);
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            DoDrawing();
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
                TmpShape.Point1 = FirstPoint;
                TmpShape.Point2 = new Point(e.X, e.Y);
                Shapes.Add(TmpShape);
                DoDrawing();
                Shapes.Remove(TmpShape);
            }
        }

        private void BtnSerealize_Click(object sender, EventArgs e)
        {
            //Serializer.DoSerialization(typeof(List<Shape>), Shapes);
            Serializer.DoSerialization(Shapes);
        }

        private void BtnDesirialized_Click(object sender, EventArgs e)
        {
            //Deserializer.DoDeserialization(typeof(List<Shape>), ref Shapes);
            Deserializer.DoDeserialization(ref Shapes);
            DoDrawing();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (Shapes.Count > 0)
            {
                TmpShape = Shapes[Shapes.Count - 1];
                Shapes.Remove(TmpShape);
                TmpShape = null;
                DoDrawing();
            }
        }
    }
}
