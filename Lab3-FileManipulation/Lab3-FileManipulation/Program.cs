using System;
using System.IO;

namespace Lab3_FileManipulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //WriteToAFile();
            //addItem();
            //removeItem();
            //Exit();
            DeleteLine("beer");
            ViewList();
        }

        public static void WriteToAFile()
        {
            string path = "../../../lab3list.txt";
            File.WriteAllText(path, "toilet paper");
        }

        public static void WriteError(string error)
        {
            string path = "../../../lab3errorLog.txt";
            File.WriteAllText(path, error);

        }

        public static void ViewList()
        {
            try
            {
                string path = "../../../lab3list.txt";
                using (StreamReader sr = File.OpenText(path))
                {
                    string text = " ";
                    while ((text = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Your file is not available", e.Message);

                WriteError(e.Message);

            }
            finally
            {
                Console.WriteLine("Process Complete");
            }
        }
        public static string[] ReadAllLines()
        {
            string path = "../../../lab3list.txt";
            string[] myText = File.ReadAllLines(path);
            return myText;
        }
        public static void DeleteLine(string ItemRemoved)
        {
            string[] words = ReadAllLines();
            string[] newWords = new string[words.Length - 1];
            int j = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != ItemRemoved)
                {
                    newWords[j] = words[i];
                    j++;
                }
                WriteToAFile(newWords);
            }
        }
        static void WriteToAFile(string[] contents)
        {
            string path = "../../../lab3list.txt";
            File.WriteAllLines(path, contents);


        }
    }


}

