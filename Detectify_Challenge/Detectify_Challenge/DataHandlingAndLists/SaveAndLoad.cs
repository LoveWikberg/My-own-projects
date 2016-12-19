using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Detectify_Challenge
{
    class SaveAndLoad
    {
        public static void WriteToJsonFile(string filePath, List<URL> list)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            var jsonString = JsonConvert.SerializeObject(list);

            File.WriteAllText(filePath, jsonString);

        }

        public static URL[] ReadFromJsonFile(string filePath)
        {
            
            if (!File.Exists(filePath))
                File.Create(filePath);

            var jsonFromFile = File.ReadAllText(filePath);
            URL[] myDeserializedArray = JsonConvert.DeserializeObject<URL[]>(jsonFromFile);

            return myDeserializedArray;
        }
    }
}
