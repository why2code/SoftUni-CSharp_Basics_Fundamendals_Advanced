using System;
using System.Text;

namespace CharsInBetween
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = Char.Parse(Console.ReadLine());
            char secondChar = Char.Parse(Console.ReadLine());

            Console.WriteLine(PrintOfCharsFromRange(firstChar, secondChar));

        }

        static string PrintOfCharsFromRange(char a, char b)
        {
            StringBuilder newString = new StringBuilder();

            if (a > b)
            {
                char tempCh = a;
                a = b;
                b = tempCh;
            }

            for (int i = a + 1; i < b; i++)
            {
                newString.Append((char)(i));
                newString.Append(' ');
            }

            return newString.ToString();
        }
    }
}
