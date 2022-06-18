using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class JsonFileStream
    {
        private static string _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}{DateTime.Today.Date.Day.ToString()}_data.json";

        public static void CreateUpdateFile(bool isNewFile, List<string> dataInput)
        {
            if (isNewFile)
            {
                WriteDataInFile(dataInput);
            }
            else
            {
                List<string> data = ReadFile();
                dataInput.AddRange(data);
                WriteDataInFile(dataInput);
            }
        }

        private static void WriteDataInFile(List<string> dataInput)
        {
            using (FileStream outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<string>>(new Utf8JsonWriter(outputStream, new JsonWriterOptions { SkipValidation = true, Indented = true })
                    ,dataInput);
            }
        }

        public static List<string> ReadFile()
        {
            List<string> dataContent = new List<string>();

            using (StreamReader jsonFileReader = File.OpenText(_jsonFileName))
            {
                dataContent = JsonSerializer.Deserialize<List<string>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }

            return dataContent;
        }
    }
}
