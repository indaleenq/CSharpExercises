using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    internal class StudentNumberTextFileStream
    {
        public static string fileName = $"{DateTime.Today.Date.Day.ToString()}_StudentNumbers.txt";

        internal static void CreateUpdateFile(bool isNewFile)
        {
            if (isNewFile)
            {
                using (StreamWriter file = File.CreateText(fileName))
                {
                    WriteDataInFile(file);
                }
            }
            else
            {
                using (StreamWriter file = File.AppendText(fileName))
                {
                    WriteDataInFile(file);
                }
            }
        }

        private static void WriteDataInFile(StreamWriter file)
        {

            string line;
            do
            {
                Console.Write("Enter Student Number: ");
                line = Console.ReadLine();

                if (line.Length != 0 && line.StartsWith("20") && line.EndsWith("BN"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
            while (line.Length != 0);

            Console.WriteLine("Exit Input Mode. Closing application..");
        }

        internal static void ReadFile()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                Console.WriteLine("FILE DATA");
                string line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine($"DATA: {line.ToUpper()}");
                    line = sr.ReadLine();
                }
            }
        }
    }
}
