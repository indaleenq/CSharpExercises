using System;
using System.IO;

namespace CSharpExercises
{
    class Program
    {
        public static string fileName = "out.txt";
        public static void Main(string[] args)
        {
            string userSelection = DisplayMenu();

            switch (userSelection)
            {
                case "1":
                    CreateUpdateFile(true);
                    break;
                case "2":
                    CreateUpdateFile(false);
                    break;
                case "3":
                    Console.WriteLine("Reading contents of the file..");
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
                    break;
                default:
                    break;
            }
        }

        public static string DisplayMenu()
        {
            Console.WriteLine("Select from MENU:");
            Console.WriteLine("Enter '1' to create the new file and input contents.");
            Console.WriteLine("Enter '2' to update the file.");
            Console.WriteLine("Enter '3' to read the file.");
            Console.WriteLine("Enter '4' to delete the file."); //TODO: implement deleting file

            Console.WriteLine();
            Console.Write("USER INPUT:");
            string userMenuSelection = Console.ReadLine();
            Console.WriteLine();

            return userMenuSelection;
        }

        public static void CreateUpdateFile(bool isNewFile)
        {
            if (isNewFile)
            {
                Console.WriteLine("Note: Creating a new file deletes the existing file...");
                using (StreamWriter file = File.CreateText(fileName))
                {
                    WriteDataInFile(file);
                }
            }
            else
            {
                Console.WriteLine("Updating the existing file...");
                using (StreamWriter file = File.AppendText(fileName))
                {
                    WriteDataInFile(file);
                }
            }
        }

        private static void WriteDataInFile(StreamWriter file)
        {
            Console.WriteLine("[INPUT MODE] Enter data you want to input in the file...(entering blank data exits input mode)");
            string line;
            do
            {
                Console.Write("DATA: ");
                line = Console.ReadLine();

                if (line.Length != 0 && line.Contains("."))
                {
                    file.WriteLine(line);
                }
            }
            while (line.Length != 0);
            Console.WriteLine("Exit Input Mode. Closing application..");
        }
    }
}