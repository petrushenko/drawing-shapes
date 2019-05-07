using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PluginInterface;

namespace draw_shapes
{
    class Deserializer
    {
        private const string ErrorMsg = "Can't decode JSON file.\nIt may be damaged.\n";

        private const string ErrorCaption = "Error";

        private const string PathToJson = "figures.json";

        //public static void DoDeserialization(ref List<Shape> list)
        //{
        //    using (StreamReader sr = new StreamReader(PathToJson))
        //    {
        //        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        //        string data = sr.ReadToEnd();
        //        try
        //        {
        //            list = JsonConvert.DeserializeObject(data, jsonSerializerSettings) as List<Shape>;
        //        }
        //        catch (Exception e)
        //        {
        //            string errorWithText = ErrorMsg + "[" + e.Message + "]";
        //            MessageBox.Show(errorWithText, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        public static void DoDeserialization(ref List<IShapePlugin> list)
        {
            using (StreamReader sr = new StreamReader(PathToJson))
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string data = sr.ReadToEnd();
                try
                {
                    list = JsonConvert.DeserializeObject(data, jsonSerializerSettings) as List<IShapePlugin>;
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
