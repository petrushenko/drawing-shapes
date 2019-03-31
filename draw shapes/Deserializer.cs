using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace draw_shapes
{
    class Deserializer
    {
        private const string ErrorMsg = "Can't decode JSON file.\nIt may be damaged.";

        private const string ErrorCaption = "Error";

        private const string PathToJson = "figures.json";

        //make for all List<object>
        public static void DoDeserialization(Type type, ref List<Shape> list)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(type);

            using (FileStream fs = new FileStream(PathToJson, FileMode.OpenOrCreate))
            {
                try
                {
                    list = jsonFormatter.ReadObject(fs) as List<Shape>;
                }
                catch(Exception e)
                {
                    MessageBox.Show(ErrorMsg, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
