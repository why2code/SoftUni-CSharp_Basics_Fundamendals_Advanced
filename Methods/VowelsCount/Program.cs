using System;
using System.Linq;

namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            Console.WriteLine(VowelsCount(textInput));

        }

        static int VowelsCount(string textInput)
        {
            int vowelsCount = 0;
            string lowerText = textInput.ToLower();
            char[] vowels = new char[] { 'a', 'e', 'o', 'u', 'i' };

            foreach (char ch in lowerText)
            {
                if (vowels.Contains(ch))
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}

        }
    }
}
