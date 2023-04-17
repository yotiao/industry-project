using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WriteTocsvfile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("", readRecord("124", "Book1.csv", 1)));
        }

        public static void addRecord(string ID, string name, string age, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(ID + "," + name + "," + age);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did OOP:", ex);
            }
        }

        public static string[] readRecord(string searchTerm, string filepath, int positonOfSearchTerm)
        {
            positonOfSearchTerm --;
            string[] recordNotFound = { "Record not found" };

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@filepath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchTerm, fields, positonOfSearchTerm))
                    {
                        Console.WriteLine("Got record");
                        return fields;

                    }

                }

                return recordNotFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine("This program did OOP");
                return recordNotFound;
                throw new ApplicationException("This program did OOP", ex);
            }

        }




        public static bool recordMatches(string searchTerm, string[] record, int positonOfSearchTerm)
        {
            if (record[positonOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }
    
    }

}
