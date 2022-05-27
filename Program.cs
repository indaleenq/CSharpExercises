using System;
using System.IO;

namespace CSharpExercises
{
    class Program
    {
        public static string fileName = $"{DateTime.Today.Date.Day.ToString()}_StudentNumbers.txt";

        public static void Main(string[] args)
        {
            string userSelection = DisplayMenu();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Note: Creating a new file deletes the existing file...");
                    CreateUpdateFile(true);
                    break;
                case "2":
                    Console.WriteLine("Updating the existing file...");
                    CreateUpdateFile(false);
                    break;
                case "3":
                    Console.WriteLine("Reading contents of the file..");
                    ReadFile();
                    break;
                default:
                    break;
            }
        }

        private static string DisplayMenu()
        {
            //create a file that will hold all student numbers
            Console.WriteLine("STUDENT NUMBERS Data - Select from MENU:");
            Console.WriteLine("Enter '1' to create a new file and input contents.");
            Console.WriteLine("Enter '2' to update or add data to the file.");
            Console.WriteLine("Enter '3' to read the file.");
            Console.WriteLine("Enter '4' to delete the file."); //TODO: implement deleting file

            Console.WriteLine();
            Console.Write("USER INPUT:");
            string userMenuSelection = Console.ReadLine();
            Console.WriteLine();

            return userMenuSelection;
        }

        private static void CreateUpdateFile(bool isNewFile)
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

        private static void ReadFile()
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