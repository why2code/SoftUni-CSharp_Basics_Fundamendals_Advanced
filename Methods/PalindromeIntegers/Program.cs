using System;

namespace PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number;
            while ((number = Console.ReadLine()) != "END")
            {
                if (IsNumberPalindrome(number))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }

        }

        static bool IsNumberPalindrome(string number)
        {
            bool isPalindrome = false;
            if (number.Length == 1)
            {
                isPalindrome = true;
            }

            for (int i = 0; i < number.Length / 2; i++)
            {
                for (int j = number.Length - 1 - i; j > number.Length / 2; j--)
                {
                    if (number[i] == number[j])
                    {
                        isPalindrome = true;
                        break;
                    }
                    else
                    {
                        isPalindrome = false;
                        break;
                    }

                }
                if (!isPalindrome)
                {
                    break;
                }

            }
            return isPalindrome;
        }
    }
}
