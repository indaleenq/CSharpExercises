using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpExercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            string userSelection = DisplayMenu();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Note: Creating a new file deletes the existing file...");
                    List<string> dataInput = GetData();
                    StudentNumberTextFileStream.CreateUpdateFile(true, dataInput);
                    break;
                case "2":
                    Console.WriteLine("Updating the existing file...");
                    List<string> dataUpdate = GetData();
                    StudentNumberTextFileStream.CreateUpdateFile(false, dataUpdate);
                    break;
                case "3":
                    Console.WriteLine("Reading contents of the file..");
                    DisplayData();
                    break;
                default:
                    break;
            }
        }

        private static string DisplayMenu()
        {
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

        private static List<string> GetData() //will get data input from user that will be passed in data class for saving
        {
            List<string> dataList = new List<string>();

            string line;
            do
            {
                Console.Write("Enter Student Number: ");
                line = Console.ReadLine();

                if (line.Length != 0 && line.StartsWith("20") && line.EndsWith("BN"))
                {
                    dataList.Add(line);
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
            while (line.Length != 0);

            Console.WriteLine("Exit Input Mode. Closing application..");

            return dataList;
        }

        private static void DisplayData()
        {
            List<string> dataContent = StudentNumberTextFileStream.ReadFile();

            foreach (var data in dataContent)
            {
                Console.WriteLine($"DATA: {data.ToUpper()}");
            }
        }
    }
}