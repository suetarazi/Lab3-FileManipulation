using System;
using System.IO;

namespace Lab3_FileManipulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteToAFile();
            ViewList();
            //addItem();
            //removeItem();
            //Exit();
        }
    
    static void WriteToAFile()
        {
            string path = "../../../lab3list.txt";
            File.WriteAllText(path, "toilet paper");
        }
    
    static void ViewList()
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
            }
            finally
            {
                Console.WriteLine("Process Complete");
            }
                }
            }
        }

