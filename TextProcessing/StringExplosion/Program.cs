using System;
using System.Text;

namespace v._2._0_StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            int bombPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currCharacter = input[i];
                if (currCharacter == '>')
                {
                    output.Append(currCharacter);
                    bombPower += (int)input[i + 1] - 48;
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower--;
                    }
                    else
                    {
                        output.Append(currCharacter);
                    }
                }

            }

            Console.WriteLine(output.ToString());
        }
    }
}
