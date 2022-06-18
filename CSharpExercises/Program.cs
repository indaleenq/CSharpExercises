using ApplicationLayer;
using Common;
using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpExercises
{
    //Program class should be our UI layer (codes related to UI)
    class Program
    {
        public static void Main(string[] args)
        {
            EnumDataName datatypeSelection = DisplayDataSelectionMenu();

            string userSelection = DisplayMenu();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Note: Creating a new file deletes the existing file...");
                    List<string> dataInput = GetData(datatypeSelection);

                    string fileTypeCreate = DisplayFileTypeMenu();
                    
                    if (fileTypeCreate == "Text")
                    {
                      TextFileStream.CreateUpdateFile(true, dataInput);
                    }
                    else if (fileTypeCreate == "Json")
                    {
                        JsonFileStream.CreateUpdateFile(true, dataInput);
                    }

                    break;
                case "2":
                    Console.WriteLine("Updating the existing file...");
                    List<string> dataUpdate = GetData(datatypeSelection);
                    string fileTypeUpdate = DisplayFileTypeMenu();

                    if (fileTypeUpdate == "Text")
                    {
                        TextFileStream.CreateUpdateFile(true, dataUpdate);
                    }
                    else if (fileTypeUpdate == "Json")
                    {
                        JsonFileStream.CreateUpdateFile(true, dataUpdate);
                    }

                    break;
                case "3":
                    Console.WriteLine("Reading contents of the file..");
                    DisplayData();
                    break;
                default:
                    break;
            }
        }

        private static string DisplayFileTypeMenu()
        {
            //create a file that will hold all student numbers
            Console.WriteLine("Select the type of file you want to use");
            Console.WriteLine("Enter '1' for Text File");
            Console.WriteLine("Enter '2' for Json File");

            Console.WriteLine();
            Console.Write("USER INPUT:");
            string userMenuSelection = Console.ReadLine();

            string fileTypeSelection = String.Empty;

            Console.WriteLine();

            switch (userMenuSelection)
            {
                case "1":
                    fileTypeSelection = "Text";
                    break;
                case "2":
                    fileTypeSelection = "Json";
                    break;
                default:
                    break;
            }

            return fileTypeSelection;
        }

        private static EnumDataName DisplayDataSelectionMenu()
        {
            //create a file that will hold all student numbers
            Console.WriteLine("Select the type of data you want to transact:");
            Console.WriteLine("Enter '1' for Student Number");
            Console.WriteLine("Enter '2' for Subject Code");

            Console.WriteLine();
            Console.Write("USER INPUT:");
            string userMenuSelection = Console.ReadLine();

            EnumDataName dataTypeSelection = EnumDataName.None;
            
            Console.WriteLine();

            switch (userMenuSelection)
            {
                case "1":
                    dataTypeSelection = EnumDataName.StudentNumber;
                    break;
                case "2":
                    dataTypeSelection = EnumDataName.SubjectCode;
                    break;
                default:
                    break;
            }

            return dataTypeSelection;
        }

        private static string DisplayMenu()
        {
            //create a file that will hold all student numbers
            Console.WriteLine("Data - Select from MENU:");
            Console.WriteLine("Enter '1' to create a new file and input contents.");
            Console.WriteLine("Enter '2' to update or add data to the file.");
            Console.WriteLine("Enter '3' to read the file.");

            Console.WriteLine();
            Console.Write("USER INPUT:");
            string userMenuSelection = Console.ReadLine();
            Console.WriteLine();

            return userMenuSelection;
        }

        private static List<string> GetData(EnumDataName dataTypeSelection) //will get data input from user that will be passed in data class for saving
        {
            List<string> dataList = new List<string>();

            string line;
            do
            {
                Console.Write("Enter Data: ");
                line = Console.ReadLine();

                if (DataValidator.ValidateData(line, dataTypeSelection))
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
            List<string> dataContent = TextFileStream.ReadFile();

            foreach (var data in dataContent)
            {
                Console.WriteLine($"DATA: {data.ToUpper()}");
            }
        }
    }
}