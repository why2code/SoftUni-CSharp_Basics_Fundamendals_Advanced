using System;

namespace ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string fileNameAndExtension = input.Substring(input.LastIndexOf('\\') + 1);
            string extension = fileNameAndExtension.Substring(fileNameAndExtension.LastIndexOf('.') + 1);
            string nameOfFile = fileNameAndExtension.Substring(0, fileNameAndExtension.LastIndexOf('.'));

            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
