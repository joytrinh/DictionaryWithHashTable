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
            int size = 26;
            FixedSizeHashTable hash = new FixedSizeHashTable(size);
            string word = "abc";
            while (word != " ")
            {
                Console.WriteLine("Please input a word: ");
                word = Console.ReadLine().Trim().ToLower();//Make sure that input words have no relevant space and their letters are lower
                bool success = Regex.IsMatch(word, @"^[a-zA-Z]+$");//Make sure that input words only contains letters
                if (success)
                    hash.insert(word);
                else
                    break;//You can type " " to stop the while loop if you don't want to add words                               
            }
            hash.write();//Print the dictionary
            Console.WriteLine("Please write a word you would like to find: ");
            string s = Console.ReadLine();
            hash.scan(s);
            Console.ReadLine();
        }
    }
    class hashNode
    {
        int _key;
        string _word;
        hashNode _next;
        public hashNode(int key, string word)
        {
            _key = key;
            _word = word;
            _next = null;
        }
        public int key
        {
            get
            {
                return _key;
            }
            set
            {
                if (value >= 0 && value <= 25) 
                {
                    _key = value;
                }
            }
        }
        public string word
        {
            get
            {
                return _word;
            }
            set
            {
                if (value != "" && Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    _word = value;
                }
            }
        }
        public hashNode next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
    }
    class FixedSizeHashTable
    {
        private int size;        
        hashNode[] hashTable;
        string filepath = @"E:\STUDY\IT\Self-Study\C#\CS50\dictionary\dictionary.txt";
        public FixedSizeHashTable(int size)
        {
            this.size = size;
            hashTable = new hashNode[size];
            for (int i = 0; i < size; i++)
                hashTable[i] = null;//Initial value of all hashNodes is null
        }
        public void insert(string word)
        {
            int key = word[0] - 97;//Value of "a" in ASCII table is 97, we want to create
            //an array with indexes from 0 to 25 (because we have 26 alphabet letters)
            hashNode hn = new hashNode(key, word);
            if (hashTable[key] == null)
                hashTable[key] = hn;
            else
            {
                hn.next = hashTable[key];
                hashTable[key] = hn;
            }
        }
        public void write()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filepath, FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    hashNode current = null;
                    for (int i = 0; i < size; i++)
                    {
                        current = hashTable[i];
                        while (current != null)
                        {
                            writer.WriteLine(current.word);
                            current = current.next;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void scan(string s)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == s)
                    {
                        Console.WriteLine("Found the word " + s);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The word " + s + " is not found");
                        break;
                    }
                }                
            }
        }
        public void check(string s)
        {
            int a = s[0] - 97;
            hashNode cursor = hashTable[a];
            bool result = false;
            if (cursor != null)
            {
                while (cursor.word != s)
                {
                    cursor = cursor.next;
                    if (cursor.word == s)
                    {
                        result = true;
                        break;
                    }
                }
            }
            else
                result = false;
            if (result)
                Console.WriteLine("The word " + s + " is found in the dictionary");
            else
                Console.WriteLine("The word " + s + " is NOT found");
        }
        public void print()
        {
            hashNode current = null;
            for (int i = 0; i < size; i++)
            {
                current = hashTable[i];
                while (current != null)
                {
                    Console.Write(current.key + ": " + current.word + " -> ");
                    current = current.next;
                }
                Console.WriteLine();
            }
        }
    }
}
