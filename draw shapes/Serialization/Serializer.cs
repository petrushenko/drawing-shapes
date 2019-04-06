﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace draw_shapes
{
    class Serializer
    {
        private const string PathToJson = "figures.json";

        public static void DoSerialization(List<Shape> list)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string output = JsonConvert.SerializeObject(list, jsonSerializerSettings);

            using (StreamWriter sr = new StreamWriter(PathToJson))
            {
                sr.Write(output);
            }
        }
    }
}
