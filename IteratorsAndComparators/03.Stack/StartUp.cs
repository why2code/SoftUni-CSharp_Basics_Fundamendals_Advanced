using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var stack = new Stack<int>();
            while (command != "END")
            {
                string[] commArgs = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (commArgs[0] == "Push")
                {
                    var valueToPush = commArgs.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(valueToPush);

                }
                else if (commArgs[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        //throw new ArgumentException(e.Message);
                        Console.WriteLine("No elements");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
