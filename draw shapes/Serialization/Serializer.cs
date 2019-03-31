using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace draw_shapes
{
    class Serializer
    {
        private const string PathToJson = "figures.json";
        //make for all List<object>
        public static void DoSerialization(Type type, List<Shape> list)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(type);

            using (FileStream fs = new FileStream(PathToJson, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }
    }
}
