using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpExercises
{
    public class StudentNumberTextFileStream
    {
        internal static string fileName = $"{DateTime.Today.Date.Day.ToString()}_StudentNumbers.txt";

        //(PROGRAM.cs) get menu selection from user --> (PROGRAM.cs) call appropriate data class method --> 
        //--> (StudentNumberTextFileStream.cs) create file --> StudentNumberTextFileStream.cs) get user input -->
        //--> (StudentNumberTextFileStream.cs) save file

        //TO-BE:
        //(PROGRAM.cs) get menu selection from user --> (PROGRAM.cs) get user data input -->
        //--> (StudentNumberTextFileStream.cs) create file --> (StudentNumberTextFileStream.cs) save data from Program.cs

        internal static void CreateUpdateFile(bool isNewFile, List<string> dataInput)
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

        internal static void WriteDataInFile(StreamWriter file, List<string> dataInput)
        {
            foreach (var data in dataInput)
            {
                file.WriteLine(data);
            }
        }

        internal static List<string> ReadFile()
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
