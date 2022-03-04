using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace OOP_Lab2_Kostenko
{
    class JsonSerialization
    {
        static JsonSerializer serializer = new JsonSerializer();
        private static string path = "C:/LabaOOP/";
        public  void SerializeToJson(object ObjectName, string filename)
        {
            using (StreamWriter file = File.CreateText(@"" + path + filename + ".json"))
            {
                serializer.Serialize(file, ObjectName);
            }
        }
        public  object DeserializeFromJson(string filename)
        {
            StreamReader file = new StreamReader(@"" + path + filename + ".json");
            string productJson = file.ReadToEnd();
            return JsonConvert.DeserializeObject<object>(productJson);
        }
    }
}
