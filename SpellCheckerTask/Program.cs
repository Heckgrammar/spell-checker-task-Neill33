using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main()
        {
            string[] words = File.ReadAllLines("WordsFile.txt");

            Console.Write("Enter a word or sentence: ");
            string userInput = Console.ReadLine().ToLower();
            string[] userWords = userInput.Split(' ');

            int correctCount = 0;
            string incorrectWords = "";

            foreach (string word in userWords)
            {
                if (Array.Exists(words, w => w.ToLower() == word))
                {
                    correctCount++;
                }
                else
                {
                    incorrectWords += word + "\n";
                }
            }

            double score = (double)correctCount / userWords.Length * 100;
            Console.WriteLine("Spelling Score: " + score + "%");

            if (incorrectWords.Length > 0)
            {
                Console.WriteLine("Misspelled words saved to 'MisspelledWords.txt'");
                File.WriteAllText("MisspelledWords.txt", incorrectWords);
            }
        }
    }


}

