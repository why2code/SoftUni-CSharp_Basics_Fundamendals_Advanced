using CommandPattern.IO.Contracts;

namespace CommandPattern.IO
{
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string output = Console.ReadLine();
            return output;
        }
    }
}
