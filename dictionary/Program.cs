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
                word = Console.ReadLine().Trim().ToLower();
                bool success = Regex.IsMatch(word, @"^[a-zA-Z]+$");
                if (success)
                    hash.insert(word);
                else
                    break;                               
            }
            hash.print();
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
                if (value != "")
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
        public FixedSizeHashTable(int size)
        {
            this.size = size;
            hashTable = new hashNode[size];
            for (int i = 0; i < size; i++)
                hashTable[i] = null;//First, set all indexes of hashTabe null value
        }
        public void insert(string word)
        {
            int key = word[0] - 97;
            hashNode hn = new hashNode(key, word);
            if (hashTable[key] == null)
                hashTable[key] = hn;
            else
            {
                hn.next = hashTable[key];
                hashTable[key] = hn;
            }
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
