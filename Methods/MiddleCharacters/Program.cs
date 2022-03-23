using System;

namespace MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(MiddleCharacters(input));

        }

        static string MiddleCharacters(string text)
        {
            int textLenght = text.Length;
            string output = string.Empty;
            if (textLenght % 2 == 0)
            {
                for (int i = (textLenght / 2) - 1; i <= (textLenght / 2); i++)
                {
                    output += text[i];
                }
            }
            else
            {
                output += text[textLenght / 2];
            }
            return output;
        }
    }
}
