using PluginInterface;
using Plugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace draw_shapes
{
    public partial class FrmMain : Form
    { 

        UserShape us;

        public bool flag = false;

        bool flag2 = false;


        private readonly string PluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        public List<IShape> ShapePlugins = new List<IShape>();

        public IShapeCreator ShapeCreator { get; set; }

        private IShape TempShape { get; set; }

        private Point FirstPoint { get; set; }

        private Bitmap BufferedPicture { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            UpdateBufferPicture();
            ShapePluginsUpload();
            InitializaStandartFidures();
            ButtonsInitialize();
        }

        private void UpdateBufferPicture()
        {
            BufferedPicture = new Bitmap(pnlDrawingArea.Width, pnlDrawingArea.Height);
        }

        private void InitializaStandartFidures()
        {
            ShapePlugins.Add(new Line());
        }

        private void ButtonsInitialize()
        {
            int X = 10;
            int Y = 10;
            foreach (IShape shapePlugin in ShapePlugins)
            {
                Button button = new Button
                {
                    Name = shapePlugin.ButtonName,
                    Tag = shapePlugin.ButtonTag,
                    Text = shapePlugin.ButtonName,
                    Location = new Point(X, Y),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top,
                };
                button.Click += ShapeButton_Click;
                Y += 25;
                pnlShapes.Controls.Add(button);
            }
            ShapePlugins.Clear();
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ShapeCreator = button.Tag as IShapeCreator;
        }

        private void ShapePluginsUpload()
        {
            ShapePlugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(PluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();
            //берем из директории все файлы с расширением .dll      
            var pluginFiles = Directory.GetFiles(PluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                //загружаем сборку
                Assembly asm = Assembly.LoadFrom(file);
                //ищем типы, имплементирующие наш интерфейс IPlugin,
                //чтобы не захватить лишнего
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.FullName == typeof(IShape).FullName).Any());

                //заполняем экземплярами полученных типов коллекцию плагинов
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IShape;
                    ShapePlugins.Add(plugin);
                }
            }
        }

        private void DoDrawing(List<IShape> shapes)
        {
            ClearScreen();
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            foreach (IShape shapePlugin in shapes)
            {
                shapePlugin.Draw(drawingArea);
            }
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
        }

        private void PnlDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            FirstPoint = new Point(e.X, e.Y);
            if (ShapeCreator != null)
            {
                
                TempShape = ShapeCreator.GetShape();
            }
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                us = new UserShape(ShapePlugins, FirstPoint, new Point(e.X, e.Y));
                flag = false;
            }

            if (flag2)
            {
                //uf.RebuildCoords(FirstPoint, new Point(e.X, e.Y));
                UserShape newUS = us.Clone() as UserShape;
                newUS.Draw(ShapePlugins, FirstPoint, new Point(e.X, e.Y));
                flag2 = false;
                ShapeCreator = new LineCreator();
            }
            if (ShapeCreator != null)
            {
                IShape currShape = ShapeCreator.GetShape();
                currShape.Point1 = FirstPoint;
                currShape.Point2 = new Point(e.X, e.Y);
                ShapePlugins.Add(currShape);
                TempShape = null;
                DoDrawing(ShapePlugins);
                //DoDrawing(uf.Shapes);
            }
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
            ShapePlugins.Clear();
            DoDrawing(ShapePlugins);
        }

        private void PnlDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShapeCreator != null)
            {
                TempShape.Point1 = FirstPoint;
                TempShape.Point2 = new Point(e.X, e.Y);
                ShapePlugins.Add(TempShape);
                DoDrawing(ShapePlugins);
                ShapePlugins.Remove(TempShape);
            }
        }

        private void BtnSerealize_Click(object sender, EventArgs e)
        {
            Serializer.DoSerialization(ShapePlugins);
        }

        private void BtnDesirialized_Click(object sender, EventArgs e)
        {
            Deserializer.DoDeserialization(ref ShapePlugins);
            DoDrawing(ShapePlugins);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            UpdateBufferPicture();
            DoDrawing(ShapePlugins);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            flag2 = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            flag = true;

            ShapeCreator = null;
            //DoDrawing(uf.Shapes);
        }
    }
}
