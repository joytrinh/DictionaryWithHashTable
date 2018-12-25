using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable dict = new Hashtable();
            string word;
            do
            {
                Console.WriteLine("Add a word: ");
                word = Console.ReadLine();
                dict.Add(word[0].ToString(), word);
            } while (word != "-1");
            ICollection keys = dict.Keys;
            foreach (string k in keys)
            {
                Console.WriteLine(k + ": " + dict[k]);
            }
            Console.ReadKey();
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
