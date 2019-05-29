using Newtonsoft.Json;
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
        private bool IsSelecting = false;

        private readonly string PluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        private List<IShapeCreator> ShapePlugins = new List<IShapeCreator>();

        private List<IShape> Shapes = new List<IShape>();

        private List<UserShapeCreator> UserShapeCreators = new List<UserShapeCreator>();
        private UserShapeCreator UserShapeCreator { get; set; }
        private IShapeCreator ShapeCreator { get; set; }

        private IShape TempShape { get; set; }

        private List<IShape> TempShapes = new List<IShape>();

        private Point FirstPoint { get; set; }

        private Bitmap BufferedPicture { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            UpdateBufferPicture();
            ShapePluginsUpload();
            InitializaStandartFidures();
            ButtonsInitialize();
            UploadUserShapes();
            ButtonsUserShapes();
        }

        public void SaveUserShapes()
        {
            string PathToJson = "user_figures.json";
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string output = JsonConvert.SerializeObject(UserShapeCreators, jsonSerializerSettings);

            using (StreamWriter sr = new StreamWriter(PathToJson))
            {
                sr.Write(output);
            }
        }

        public void UploadUserShapes()
        {
            string ErrorMsg = "Can't decode JSON file.\nIt may be damaged.\n";

            string ErrorCaption = "Error";

            string PathToJson = "user_figures.json";
            using (StreamReader sr = new StreamReader(PathToJson))
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                };
                string data = sr.ReadToEnd();
                try
                {
                    UserShapeCreators = (List<UserShapeCreator>)JsonConvert.DeserializeObject(data, jsonSerializerSettings);
                    if (UserShapeCreators == null)
                    {
                        UserShapeCreators = new List<UserShapeCreator>();
                    }
                }
                catch (Exception e)
                {
                    string errorWithText = ErrorMsg + "[" + e.Message + "]";
                    MessageBox.Show(errorWithText, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 70, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void UpdateBufferPicture()
        {
            BufferedPicture = new Bitmap(pnlDrawingArea.Width, pnlDrawingArea.Height);
        }

        private void ButtonUserShape_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            UserShapeCreator = button.Tag as UserShapeCreator;
            ShapeCreator = null;
        }

        private void InitializaStandartFidures()
        {
            ShapePlugins.Add(new LineCreator());
        }

        private void ButtonsInitialize()
        {
            pnlShapes.Controls.Clear();
            int X = 10;
            int Y = 10;
            foreach (IShapeCreator shapePlugin in ShapePlugins)
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

        private void ButtonsUserShapes()
        {
            pnlUserShapes.Controls.Clear();
            int X = 10;
            int Y = 10;
            foreach (UserShapeCreator userShapeCreator in UserShapeCreators)
            {
                Button button = new Button
                {
                    Name = userShapeCreator.Name,
                    Text = userShapeCreator.Name,
                    Tag = userShapeCreator,
                    Location = new Point(X, Y),
                };
                button.Click += ButtonUserShape_Click;
                pnlUserShapes.Controls.Add(button);
                Y += 25;
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ShapeCreator = button.Tag as IShapeCreator;
            UserShapeCreator = null;
        }

        private void ShapePluginsUpload()
        {
            Shapes.Clear();

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
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.FullName == typeof(IShapeCreator).FullName).Any());

                //заполняем экземплярами полученных типов коллекцию плагинов
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IShapeCreator;
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
        }

        private void PnlDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsSelecting)
            {
                string shapeName = ShowDialog("Enter the shape name:", "");

                if (shapeName != null)
                {
                    UserShapeCreators.Add(new UserShapeCreator(Shapes, FirstPoint, new Point(e.X, e.Y), shapeName));
                    ButtonsUserShapes();
                }
                IsSelecting = false;
                DoDrawing(Shapes);
            }
            if (UserShapeCreator != null)
            {
                UserShape userShape = UserShapeCreator.GetUserShape();
                userShape.CopyToListShapes(Shapes, FirstPoint, new Point(e.X, e.Y));
                DoDrawing(Shapes);
            }

            if (ShapeCreator != null)
            {
                IShape currShape = ShapeCreator.GetShape();
                currShape.Point1 = FirstPoint;
                currShape.Point2 = new Point(e.X, e.Y);
                Shapes.Add(currShape);
                TempShape = null;
                DoDrawing(Shapes);
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
            Shapes.Clear();
            DoDrawing(Shapes);
        }

        private void PnlDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && UserShapeCreator != null)
            {
                UserShape userShape = UserShapeCreator.GetUserShape();
                userShape.CopyToListShapes(TempShapes, FirstPoint, new Point(e.X, e.Y));
                foreach (IShape shape in TempShapes)
                {
                    Shapes.Add(shape);
                }
                DoDrawing(Shapes);
                foreach (IShape shape in TempShapes)
                {
                    Shapes.Remove(shape);
                }
                TempShapes.Clear();
            }

            if (e.Button == MouseButtons.Left && IsSelecting)
            {
                RedRectangle redRectangle = new RedRectangle();
                redRectangle.Point1 = FirstPoint;
                redRectangle.Point2 = new Point(e.X, e.Y);
                Shapes.Add(redRectangle);
                DoDrawing(Shapes);
                Shapes.Remove(redRectangle);
            }

            if (e.Button == MouseButtons.Left && ShapeCreator != null)
            {
                TempShape = ShapeCreator.GetShape();
                TempShape.Point1 = FirstPoint;
                TempShape.Point2 = new Point(e.X, e.Y);
                Shapes.Add(TempShape);
                DoDrawing(Shapes);
                Shapes.Remove(TempShape);
            }
        }

        private void BtnSerealize_Click(object sender, EventArgs e)
        {
            Serializer.DoSerialization(Shapes);
        }

        private void BtnDesirialized_Click(object sender, EventArgs e)
        {
            Deserializer.DoDeserialization(ref Shapes);
            DoDrawing(Shapes);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                UpdateBufferPicture();
                DoDrawing(Shapes);
            }
        }

        private void BtnCreateShape_Click(object sender, EventArgs e)
        {
            IsSelecting = true;
            ShapeCreator = null;
            UserShapeCreator = null;
        }

        private void BtnDeleteUserFigure_Click(object sender, EventArgs e)
        {
            if (UserShapeCreator != null)
            {
                UserShapeCreators.Remove(UserShapeCreator);
                ButtonsUserShapes();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserShapes();
        }
    }
}
