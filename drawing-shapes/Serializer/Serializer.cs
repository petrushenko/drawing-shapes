using Newtonsoft.Json;
using PluginInterface;
using System.Collections.Generic;
using System.IO;

namespace draw_shapes
{
    class Serializer
    {
        private const string PathToJsonShapes = "shapes.json";

        private const string PathToJsonUserShapes = "user_shapes.json";

        public static void DoSerialization(List<IShape> list)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string output = JsonConvert.SerializeObject(list, jsonSerializerSettings);

            using (StreamWriter sr = new StreamWriter(PathToJsonShapes))
            {
                sr.Write(output);
            }
        }

        public static void DoSerializationUserShapes(List<UserShapeCreator> list)
        {

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string output = JsonConvert.SerializeObject(list, jsonSerializerSettings);

            using (StreamWriter sr = new StreamWriter(PathToJsonUserShapes))
            {
                sr.Write(output);
            }
        }


    }
}
