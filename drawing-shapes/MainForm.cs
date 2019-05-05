﻿using PluginInterface;
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

        public List<IShapePlugin> ShapePlugins = new List<IShapePlugin>();

        public IShapeCreatorPlugin ShapeCreator { get; set; }

        private IShapePlugin TempShape { get; set; }
        private Shape TmpShape { get; set; }

        private List<Shape> Shapes = new List<Shape>();

        private Point FirstPoint { get; set; }

        private Bitmap BufferedPicture { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            BufferedPicture = new Bitmap(pnlDrawingArea.Width, pnlDrawingArea.Height);
            ShapePluginsUpload();
            ButtonsInitialize();
        }

        private void ButtonsInitialize()
        {
            int X = 700;
            int Y = 10;
            foreach (IShapePlugin shapePlugin in ShapePlugins)
            {
                Button button = new Button
                {
                    Name = shapePlugin.ButtonName,
                    Tag = shapePlugin.ButtonTag,
                    Text = shapePlugin.ButtonName,
                    Location = new Point(X, Y),
                };
                button.Click += ShapeButton_Click;
                Y += 25;
                Controls.Add(button);
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ShapeCreator = button.Tag as IShapeCreatorPlugin;
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
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.FullName == typeof(IShapePlugin).FullName).Any());

                //заполняем экземплярами полученных типов коллекцию плагинов
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IShapePlugin;
                    ShapePlugins.Add(plugin);
                }
            }
        }

        private void DoDrawing()
        {
            ClearScreen();
            Graphics drawingArea = Graphics.FromImage(BufferedPicture);
            //foreach (Shape shape in Shapes)
            //{
            //    shape.Draw(drawingArea);
            //}
            foreach (IShapePlugin shapePlugin in ShapePlugins)
            {
                shapePlugin.Draw(drawingArea);
            }
            pnlDrawingArea.Image = BufferedPicture;
            drawingArea.Dispose();
        }

        private void PnlDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            //if (CurrentShapeCreator != null)
            //{
            //    FirstPoint = new Point(e.X, e.Y);
            //    TmpShape = CurrentShapeCreator.GetInstance();
            //}
            if (ShapeCreator != null)
            {
                FirstPoint = new Point(e.X, e.Y);
                TempShape = ShapeCreator.GetShape();
            }
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            //if (CurrentShapeCreator != null)
            //{
            //    Shape currShape = CurrentShapeCreator.GetInstance();
            //    currShape.Point1 = FirstPoint;
            //    currShape.Point2 = new Point(e.X, e.Y);
            //    Shapes.Add(currShape);
            //    TmpShape = null;
            //    DoDrawing();
            //}
            if (ShapeCreator != null)
            {
                IShapePlugin currShape = ShapeCreator.GetShape();
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
            //!!!!!
            Shapes.Clear();
            ShapePlugins.Clear();
            DoDrawing();
        }

        private void PnlDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShapeCreator != null)
            {
                //TmpShape.Point1 = FirstPoint;
                //TmpShape.Point2 = new Point(e.X, e.Y);
                //Shapes.Add(TmpShape);
                //DoDrawing();
                //Shapes.Remove(TmpShape);
                TempShape.Point1 = FirstPoint;
                TempShape.Point2 = new Point(e.X, e.Y);
                ShapePlugins.Add(TempShape);
                DoDrawing();
                ShapePlugins.Remove(TempShape);
            }
        }

        private void BtnSerealize_Click(object sender, EventArgs e)
        {
            //Serializer.DoSerialization(typeof(List<Shape>), Shapes);
            Serializer.DoSerialization(Shapes);
            Serializer.DoSerialization(ShapePlugins);
        }

        private void BtnDesirialized_Click(object sender, EventArgs e)
        {
            //Deserializer.DoDeserialization(typeof(List<Shape>), ref Shapes);
            Deserializer.DoDeserialization(ref Shapes);
            Deserializer.DoDeserialization(ref ShapePlugins);
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