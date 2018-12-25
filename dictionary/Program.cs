using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable dict = new Hashtable();

            //1. Calls load on the dictionary file
            string word = "";
            while (word != " ")
            {
                Console.WriteLine("Add a word: ");
                word = Console.ReadLine().ToLower().Trim();//Lower all letters and trim irrelevant spaces

                //Dictionary contains valid words
                bool success = Regex.IsMatch(word, @"^[a-zA-Z]\[']+$");
                if (success)
                    dict.Add(word[0].ToString(), word);
                else
                    Console.WriteLine("Please enter words with letters only!");
            };
            ICollection keys = dict.Keys;
            using (StreamWriter file = new StreamWriter(@"E:\STUDY\IT\Self-Study\C#\CS50\dictionary\dictionary.txt"))
            {
                foreach (string k in keys)
                {
                    file.WriteLine(k + ": " + dict[k]);
                }
            }                
            
            //
        }
    }
    class Node
    {
        public Node next = null;
        public object data;
        public Node(object val)
        {
            data = val;
        }
    }
}
