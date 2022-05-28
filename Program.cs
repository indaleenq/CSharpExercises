using System;
using System.IO;

namespace CSharpExercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            //testing change
            string userSelection = DisplayMenu();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Note: Creating a new file deletes the existing file...");
                    StudentNumberTextFileStream.CreateUpdateFile(true);
                    break;
                case "2":
                    Console.WriteLine("Updating the existing file...");
                    StudentNumberTextFileStream.CreateUpdateFile(false);
                    break;
                case "3":
                    Console.WriteLine("Reading contents of the file..");
                    StudentNumberTextFileStream.ReadFile();
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
    }
}