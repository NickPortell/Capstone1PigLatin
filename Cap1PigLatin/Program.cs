using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap1PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = "y";
            string input, newLine="", changedWord, pigLatinString;
            bool capitals, numbers, word1, punctuation;

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            while(response == "y")
            {
                Console.Write("\nEnter a line to be translated: ");
                input = Console.ReadLine();
                Console.WriteLine();

                //char[] letters = input.ToArray();

                if (input != null)
                {
                    string[] words = input.Split(' '); //creates a an array of strings delimited by " "
                    //comeback to this!!


                    for (int i = 0; i < words.Length; i++)
                    {
                        capitals = IsAllCaps(words[i]);
                        numbers = HasNumbers(words[i]);
                        //word1 should be delcared here
                        punctuation = HasPunctuation(words[i]);

                        if(i == 0)
                        {
                            word1 = true;
                        }
                        else
                        {
                            word1 = false;
                        }

                        if(numbers)
                        {
                            words[i] += " ";

                            if(punctuation)
                            {
                                char p = ReturnPunctuation(words[i]);
                                string stripped = StripPunctuation(p, words[i]);
                                newLine += stripped + p + " "; //this is the new sentence
                            }
                        }

                        if(punctuation && !word1)
                        {
                            char p = ReturnPunctuation(words[i]);
                            string stripped = StripPunctuation(p, words[i]);

                            changedWord = ToPigLatin(stripped);
                            newLine += changedWord + p + " ";
                        }

                        if(punctuation && word1 && !numbers)
                        {
                            char p = ReturnPunctuation(words[i]);
                            string stripped = StripPunctuation(p, words[i]);
                            string strippedLowered = stripped.ToLower();

                            changedWord = ToPigLatin(strippedLowered);
                            pigLatinString = changedWord.ToString();
                            pigLatinString = TitleCase(pigLatinString);
                            newLine += pigLatinString + p + " ";
                        }

                        if(capitals)
                        {
                            changedWord = ToPigLatin(words[i]);
                            pigLatinString = changedWord.ToString();
                            pigLatinString = CapsAll(pigLatinString);
                            newLine += pigLatinString + " ";
                        }

                        if (word1 && !capitals && !numbers && !punctuation)
                        {
                            words[0] = words[0].ToLower();
                            changedWord = ToPigLatin(words[0]);
                            pigLatinString = changedWord.ToString();
                            pigLatinString = TitleCase(pigLatinString);
                            newLine += pigLatinString + " ";
                        }

                        if(!word1 && !capitals && !numbers && !punctuation)
                        {
                            words[i] = words[i].ToLower();
                            changedWord = ToPigLatin(words[i]);
                            newLine += changedWord + " ";

                        }

                    }
                    Console.WriteLine(newLine);
                    newLine = "";


                }
                else
                {
                    Console.WriteLine("That did not contain words.");
                }
                Console.Write("Translate another line? (y/n): ");
                response = Console.ReadLine();
            }
        }
        public static bool IsVowel(char input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u','A','E','I','O','U' };
            
            if(vowels.Contains(input))
            {
                return true;
            }
            return false;
        }
        public static int FindFirstVowel(string input)
        {
            char[] letters = input.ToArray();

            for(int i = 0; i < letters.Length; i++)
            {
                if(IsVowel(letters[i]))
                {
                    return i;
                }
            }
            return 0;
        }
        public static bool VowelAtStart(string input)
        {
            char[] letters = input.ToArray();

            return IsVowel(letters[0]);
        }
        public static bool IsCapitalized(char input)
        {
            char[] capitals = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            if(capitals.Contains(input))
            {
                return true;
            }
            return false;
        }
        public static bool CapitalAtStart(string input)
        {
            char[] letters = input.ToArray();

            return IsCapitalized(letters[0]);
        }
        public static bool IsAllCaps(string input)
        {
            char[] letters = input.ToArray();
            int caps = 0;

            for(int i = 0; i < letters.Length; i++)
            {
                if(IsCapitalized(letters[i]))
                {
                    caps++;
                }
            }
            if (caps == (letters.Length))
            {
                return true;
            }
            return false;
        }
        public static bool IsNumber(char input)
        {
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            if (numbers.Contains(input))
            {
                return true;
            }
            return false;
        }
        public static bool HasNumbers(string input)
        {
            char[] letters = input.ToArray();

            for(int i = 0; i < letters.Length; i++)
            {
                if(IsNumber(letters[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsSymbol(char input)
        {
            char[] symbols = { '`', '~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', '{', '}', ']', ';', ':', '\'', '\\', '|', '"', '<', '>', '/' };

            if(symbols.Contains(input))
            {
                return true;
            }
            return false;
        }
        public static bool HasSymbols(string input)
        {
            char[] letters = input.ToArray();

            for(int i = 0; i < letters.Length; i++)
            {
                if(IsSymbol(letters[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsPunctuation(char input)
        {
            char[] punctuation = { '!', ',', '.', '?' };

            if(punctuation.Contains(input))
            {
                return true;
            }
            return false;
        }
        public static bool HasPunctuation(string input)
        {
            char[] letters = input.ToArray();

            for(int i = 0; i < letters.Length; i++)
            {
                if(IsPunctuation(letters[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static char ToCapital(char input)
        {
            //string capital = new string(input);
            //capital = capital.ToUpper();
            string capital = (input.ToString()).ToUpper();
            char[] letter = capital.ToCharArray();
            return letter[0];
        }
        public static string TitleCase(string input)
        {
            char[] letters = input.ToArray();

            letters[0] = ToCapital(letters[0]);

            string s = new string(letters);
            return s;
            //return letters.ToString();
        }
        public static string CapsAll(string input)
        {
            char[] letters = input.ToArray();


            for(int i =0; i < letters.Length; i++)
            {
                letters[i] = ToCapital(letters[i]);
            }
            string s = new string(letters);
            return s;
            //return letters.ToString();
        }

        public static char ReturnPunctuation(string input)
        {
            char[] letters = input.ToArray();

            for(int i = 0; i < letters.Length;i++)
            {
                if(IsPunctuation(letters[i]))
                {
                    return letters[i];
                }
            }
            return '0';
        }
        public static string StripPunctuation(char punctuation, string input)
        {
            char[] letters = input.ToArray();
            string word = "";

            for(int i = 0; i < letters.Length; i++)
            {
                if(letters[i] != punctuation)
                {
                    word += letters[i];
                }
            }
            return word;
        }

        public static string ToPigLatin(string input)
        {
            int firstVowel;
            string frontCons, restOfWord;

            if (VowelAtStart(input))
            {
                return input + "way";
            }
            else
            {
                firstVowel = FindFirstVowel(input);
                frontCons = input.Remove(firstVowel);
                restOfWord = input.Substring(firstVowel); //creates string from index chosen to the end of string 
                return restOfWord + frontCons + "ay";
            }
        }
        
        
    }
}
