using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sortedDictionaryExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading file...
            String[] lines = File.ReadAllLines("PhoneBook.txt");

            //build sorteddictionary...
            SortedDictionary<string, SortedDictionary<string, string>> phoneBook = new SortedDictionary<string, SortedDictionary<string, string>>();
          
            foreach (string line in lines)
            {
                String[] split = line.Split('|');
                //split[0] = name , split[1] = city , split[2] = phone number
                SortedDictionary<string, string> nameNumber;

                if (!phoneBook.TryGetValue(split[1], out nameNumber))
                {
                    nameNumber = new SortedDictionary<string, string>();
                    phoneBook.Add(split[1], nameNumber);
                }
                
                nameNumber.Add(split[0], split[2]);

            }

            SortedDictionary<string, SortedDictionary<string, string>>.KeyCollection keys = phoneBook.Keys;
           
            // Print the information by city...
            foreach (string city in keys)
            {

                Console.WriteLine(city + ":");
                SortedDictionary<string, string> nameNumber = phoneBook[city];
           
                foreach (var nmNmbr in nameNumber)
                {
                    Console.WriteLine("\t{0} - {1}", nmNmbr.Key, nmNmbr.Value);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}

           
   