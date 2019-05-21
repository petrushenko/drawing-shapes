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

        private void DoDrawing()
        {
            ClearScreen();
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            foreach (IShape shapePlugin in ShapePlugins)
            {
                shapePlugin.Draw(drawingArea);
            }
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
        }

        private void PnlDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (ShapeCreator != null)
            {
                FirstPoint = new Point(e.X, e.Y);
                TempShape = ShapeCreator.GetShape();
            }
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (ShapeCreator != null)
            {
                IShape currShape = ShapeCreator.GetShape();
                currShape.Point1 = FirstPoint;
                currShape.Point2 = new Point(e.X, e.Y);
                ShapePlugins.Add(currShape);
                TempShape = null;
                DoDrawing();
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
            DoDrawing();
        }

        private void PnlDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShapeCreator != null)
            {
                TempShape.Point1 = FirstPoint;
                TempShape.Point2 = new Point(e.X, e.Y);
                ShapePlugins.Add(TempShape);
                DoDrawing();
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
            DoDrawing();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            UpdateBufferPicture();
            DoDrawing();
        }
    }
}
