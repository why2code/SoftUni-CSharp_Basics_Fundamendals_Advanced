using System;
using System.Collections.Generic;

namespace _02_BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string paranthes = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isMatching = true;

            if (paranthes.Length <= 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < paranthes.Length; i++)
            {

                if (paranthes[i] == '('
                    || paranthes[i] == '{'
                    || paranthes[i] == '['
                    || paranthes[i] == ' ')
                {
                    stack.Push(paranthes[i]);
                }
                else if (paranthes[i] == ')'
                    || paranthes[i] == '}'
                    || paranthes[i] == ']')
                {

                    char lastChar = stack.Pop();
                    if ((paranthes[i] == ']' || paranthes[i] == '}')
                              && paranthes[i] == (lastChar + 2))
                    {
                        continue;
                    }
                    else if ((paranthes[i] == ']' || paranthes[i] == '}')
                              && paranthes[i] != (lastChar + 2))
                    {
                        isMatching = false;
                        Console.WriteLine("NO");
                        break;
                    }
                    else if (paranthes[i] == ')'
                              && paranthes[i] == (lastChar + 1))
                    {
                        continue;
                    }
                    else if (paranthes[i] == ')'
                              && paranthes[i] != (lastChar + 1))
                    {
                        isMatching = false;
                        Console.WriteLine("NO");
                        break;
                    }
                    else if (paranthes[i - 1] == ' ' //this means current position is ' ', so we check if previous was also ' '
                        && paranthes.Length % 2 == 0)
                    {
                        stack.Pop();
                        i--;
                        continue;
                    }
                    else if (paranthes[i - 1] == ' ' //this means current position is ' ' and in the middle, so we continue for next check
                        && paranthes.Length % 2 != 0)
                    {
                        continue;
                    }
                    else
                    {
                        isMatching = false;
                        Console.WriteLine("NO");
                        break;
                    }


                }
                else
                {
                    Console.WriteLine("NO");
                    break;
                }
            }

            if (isMatching)
            {
                Console.WriteLine("YES");
            }

        }
    }
}
