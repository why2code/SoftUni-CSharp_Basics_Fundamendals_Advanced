using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> tempState = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string cmd = Console.ReadLine();

                if (cmd.StartsWith("1"))
                {
                    tempState.Push(text.ToString());
                    string currentText = cmd.Substring(2);
                    text.Append(currentText);
                }
                else if (cmd.StartsWith("2"))
                {
                    tempState.Push(text.ToString());
                    if (text.Length == 0)
                    {
                        continue;
                    }
                    int elementsToDelete = int.Parse(cmd.Substring(2));
                    //abc, 3
                    text.Remove(text.Length - elementsToDelete, elementsToDelete);
                }
                else if (cmd.StartsWith("3"))
                {
                    int elementsToPrint = int.Parse(cmd.Substring(2));
                    Console.WriteLine(text[elementsToPrint - 1]);
                }
                else if (cmd.StartsWith("4"))
                {
                    string oldState = tempState.Pop();
                    text = text.Clear();
                    text.Append(oldState);
                }

            }
        }
    }
}
