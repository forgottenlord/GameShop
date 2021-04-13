using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestShop.IO
{
    public static class JsonParser
    {
        public static T Load<T>(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
        }
        public static void Save<T>(T obj, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(JsonConvert.SerializeObject(obj));
            }
        }
    }
}
