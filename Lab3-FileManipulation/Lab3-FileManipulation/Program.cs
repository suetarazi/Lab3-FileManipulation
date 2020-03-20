using System;
using System.IO;

namespace Lab3_FileManipulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start();
        }
         /// <summary>
         /// Main start method that calls Menu
         /// </summary>
        static void Start()
        {
            
            char input = Menu();
            try
            {
                
                if (input == '1')
                {
                    ViewList();
                    Start();
                }
                else if (input == '2')
                {
                    Console.WriteLine("How many items would you like to add?: ");
                    string inputString = Console.ReadLine();
                    int convertedInputed = Convert.ToInt32(inputString);
                    string[] array = new string[convertedInputed];
                    WordsArray(array);
                    ViewList();
                    Start();
                }
                else if (input == '3')
                {
                    Console.WriteLine("Survival List");
                    ViewList();
                    Console.WriteLine("Which item would you like to delete?: ");
                    string inputDelete = Console.ReadLine();
                    DeleteItem(inputDelete);
                    Console.WriteLine($"You have succesfully removed {inputDelete}.");
                    Start();
                }
                else if (input == '4')
                {
                    Console.WriteLine("How many items for you new survival: ");
                    string inputString = Console.ReadLine();
                    int convertedInputed = Convert.ToInt32(inputString);
                    string[] array = new string[convertedInputed];
                    WriteLinesToAFile(array);
                    Console.Write($"You have succuessfull added {convertedInputed} item(s) ");
                    Console.WriteLine("to your new survival list");
                    ViewList();
                    Start();    
                }
                else if (input == 'x')
                {
                    Environment.Exit(0);
                }
                    
                else
                {
                    Start();
                }
                
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        static char Menu()
        {
            Console.WriteLine("Here is your Survival List. What would you like to do? ");
            Console.WriteLine("'1' - Check survival list");
            Console.WriteLine("'2' - Add item to survival list");
            Console.WriteLine("'3' - Remove item to survival list");
            Console.WriteLine("'4' - Delete list, and create a new one");
            Console.WriteLine("'x' - Exit");
            string input = Console.ReadLine();
            char character = Convert.ToChar(input);
            return character;
        }

        /// <summary>
        /// Input array for items to add to the array
        /// </summary>
        /// <param name="arr">array to hold items</param>
        static void WordsArray(string[] arr)
        {
            string input;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Enter an item: ");
                input = Console.ReadLine();
                arr[i] = input;
            }
            FileAppendText(arr);
        }

        /// <summary>
        /// Writing items to a file
        /// </summary>
        /// <param name="contents">contents to be written to a file</param>
        public static void WriteLinesToAFile(string[] contents)
        {
            WordsArray(contents);
            string path = "../../../test.txt";
            File.WriteAllLines(path, contents);
        }
        public static void WriteToAFile(string[] contents)
        {
            string path = "../../../test.txt";
            File.WriteAllLines(path, contents);
        }
        public static void FileAppendText(string[] contents)
        {
            try
            {
                string path = "../../../test.txt";
                File.AppendAllLines(path, contents);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Uh oh. Something went wrong. {e.Message}");
            }
        }

        /// <summary>
        /// Returns array of items from file and returns value
        /// </summary>
        /// <returns>myText array</returns>
        static string[] ReadAllLines()
        {
            string path = "../../../test.txt";
            string[] myText = File.ReadAllLines(path);
            return myText;
        }

        /// <summary>
        /// View List from file
        /// </summary>
        public static string ViewList()
        {
            string[] textString = new string[10];
            try
            {

                string text = " ";
                string path = "../../../test.txt";
                using (StreamReader sr = File.OpenText(path))
                {
                    int i = 0; 
                
                    while ((text = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                        textString[i] = text;
                        i++;
                    }
                }
                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Your file is not available", e.Message);
            }
        
            finally
            {
                Console.WriteLine("Process Complete");
            }
            return GetWordsInArray(textString);      
            
        }

        /// <summary>
        /// Delete item from list
        /// </summary>
        /// <param name="textToRemove">name of item to remove</param>
        public static void DeleteItem(string textToRemove)
        {
            string[] words = ReadAllLines();
            string[] newWords = new string[words.Length - 1];
            int j = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != textToRemove)
                {
                    newWords[j] = words[i];
                    j++;
                }
            }
            WriteToAFile(newWords);
            Start();
        }
        public static string GetWordsInArray(string[] arr)
        {
            string str = "{ ";
            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]}, ";
            }
            return $"{str}}}";
        }
    }
}


