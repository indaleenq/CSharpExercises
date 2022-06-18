using System;
using System.Collections.Generic;
using System.IO;

namespace DataLayer
{
    //Data Layer
    public class TextFileStream
    {
        internal static string fileName = $"{DateTime.Today.Date.Day.ToString()}_data.txt";

        public static void CreateUpdateFile(bool isNewFile, List<string> dataInput)
        {
            if (isNewFile)
            {
                using (StreamWriter file = File.CreateText(fileName))
                {
                    WriteDataInFile(file, dataInput);
                }
            }
            else
            {
                using (StreamWriter file = File.AppendText(fileName))
                {
                    WriteDataInFile(file, dataInput);
                }
            }
        }

        private static void WriteDataInFile(StreamWriter file, List<string> dataInput)
        {
            foreach (var data in dataInput)
            {
                file.WriteLine(data);
            }
        }

        public static List<string> ReadFile()
        {
            List<string> dataContent = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                Console.WriteLine("FILE DATA");
                string line = sr.ReadLine();

                while (line != null)
                {
                    dataContent.Add(line);
                    line = sr.ReadLine();
                }
            }

            return dataContent;
        }
    }
}
