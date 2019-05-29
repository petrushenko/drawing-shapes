using Newtonsoft.Json;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace draw_shapes
{
    class Deserializer
    {
        private const string ErrorMsg = "Can't decode JSON file.\nIt may be damaged.\n";

        private const string ErrorCaption = "Error";

        private const string PathToJsonShapes = "shapes.json";

        private const string PathToJsonUserShapes = "user_shapes.json";

        public static void DoDeserialization(ref List<IShape> list)
        {
            if (!File.Exists(PathToJsonShapes))
            {
                File.Create(PathToJsonShapes);
            }

            using (StreamReader sr = new StreamReader(PathToJsonShapes))
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string data = sr.ReadToEnd();
                try
                {
                    list = JsonConvert.DeserializeObject(data, jsonSerializerSettings) as List<IShape>;
                    if (list == null)
                    {
                        list = new List<IShape>();
                    }
                }
                catch (Exception e)
                {
                    string errorWithText = ErrorMsg + "[" + e.Message + "]";
                    MessageBox.Show(errorWithText, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void DoDeserializationUserShapes(ref List<UserShapeCreator> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (!File.Exists(PathToJsonUserShapes))
            {
                File.Create(PathToJsonUserShapes);
            }

            using (StreamReader sr = new StreamReader(PathToJsonUserShapes))
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                };
                string data = sr.ReadToEnd();
                try
                {
                    list = (List<UserShapeCreator>)JsonConvert.DeserializeObject(data, jsonSerializerSettings);
                    if (list == null)
                    {
                        list = new List<UserShapeCreator>();
                    }
                }
                catch (Exception e)
                {
                    string errorWithText = ErrorMsg + "[" + e.Message + "]";
                    MessageBox.Show(errorWithText, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
