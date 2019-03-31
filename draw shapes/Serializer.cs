using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace draw_shapes
{
    class Serializer
    {
        //make for all List<object>
        public static void DoSerialization(Type type, List<Shape> list)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(type);

            const string PathToJson = "figures.json";

            using (FileStream fs = new FileStream(PathToJson, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }
    }
}
