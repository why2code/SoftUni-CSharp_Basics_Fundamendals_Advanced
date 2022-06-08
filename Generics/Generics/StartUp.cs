using System;


namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //===============================================================================
            //2. Generic Box of Integers
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<int>(int.Parse(input));
                Console.WriteLine(box.ToString());
            }

            ////===============================================================================
            ////1. Generic Box of String
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine();
            //    var box = new Box<string>(input);
            //    Console.WriteLine(box.ToString());
            //}
        }
    }
}
