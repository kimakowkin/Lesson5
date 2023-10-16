using System;
using System.Text;

namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindMinMaxString();
            FindShortestWord();
            FindPalindrome();
            DoubleString();
        }


        // Дана строка произвольной длины с произвольными словами.
        // Найти самое короткое слово в строке и вывести его на экран. x
        // Найти самое длинное слово в строке и вывести его на экран.
        // Если таких слов несколько, то вывести последнее из них.
        static void FindMinMaxString()
        {
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine() ?? "";
            var words = line.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            // word1 wooord2 wooord3 woord4

            int minLength = words[0].Length;
            foreach(string word in words)
            {
                minLength = word.Length < minLength ? word.Length : minLength;
            }

            string[] minWords = words.Where(x => x.Length == minLength).ToArray();
            Console.WriteLine("Самое короткое слово: " + minWords[minWords.Length - 1]);

            int maxLength = words[0].Length;
            foreach (string word in words)
            {
                maxLength = word.Length > maxLength ? word.Length : maxLength;
            }

            string[] maxWords = words.Where(x => x.Length == maxLength).ToArray();
            Console.WriteLine("Самое длинное слово: " + maxWords[minWords.Length - 1]);
        }

        // Дана строка произвольной длины с произвольными словами.
        // Найти слово, в котором число различных символов минимально.Слово
        // может содержать буквы и цифры.Если таких слов несколько, найти первое
        // из них. Например, в строке "fffff ab f 1234 jkjk" найденное слово должно быть "fffff".

        static void FindShortestWord()
        {
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine() ?? "";

            string[] words = line.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            string minWord = words[0];
            int minCount = words[0].Distinct().Count();
            foreach(string word in words)
            {
                int distinctCount = word.Distinct().Count();
                if(distinctCount < minCount)
                {
                    minCount = distinctCount;
                    minWord = word;
                }
            }

            Console.WriteLine(minWord);
        }

        // Дана строка произвольной длины с произвольными словами.
        // Написать программу для проверки является ли любое выбранное слово в строке палиндромом.
        // Например, есть строка, вводится число 3, значит необходимо проверить
        // является ли 3-е слово в этой строке палиндромом.
        // Предусмотреть предупреждающие сообщения на случаи ошибочных
        // ситуаций: например, в строке 5 слов, а на вход программе передали число
        // 500 и т. п.ситуации.

        static void FindPalindrome()
        {
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine() ?? "";

            string[] words = line.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if(words.Length == 0)
            {
                Console.WriteLine("Нет слов для работы");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Введите индекс слова для проверки: ");

            int index = 0;
            try 
            {
               index = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Некорректный ввод индекса");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            string word = words[index - 1];
            if(new string(word.Reverse().ToArray()) == word)
            {
                Console.WriteLine("Палиндром");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(word.Reverse() + " не равен " + word);
                Console.ReadLine();
            }


        }

        // Вывести на консоль новую строку, которой задублирована каждая буква из начальной строки.
        // Например, "Hello" -> "HHeelllloo".

        static void DoubleString()
        {
            Console.WriteLine("Введите строку: ");

            string input = Console.ReadLine() ?? "";

            StringBuilder doubleLine = new StringBuilder();

            foreach(char c in input)
            {
                doubleLine.Append(c);
                doubleLine.Append(c);
            }

            string output = doubleLine.ToString();

            Console.WriteLine(output);
        }
    }
}