using System;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] pass = Console.ReadLine().ToCharArray();
            for (int i = 0; i < pass.Length; i++)
            {
                pass[i] += (char)3;
            }

            Console.WriteLine(pass);
        }
    }
}
