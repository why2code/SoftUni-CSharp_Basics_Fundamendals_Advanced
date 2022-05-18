using System;
using System.Linq;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] paranthes = Console.ReadLine().ToCharArray();
            bool isBalanced = true;

            if (paranthes.Length == 1)
            {
                Console.WriteLine("NO");
                return;
            }
            else
            {
                for (int i = 0; i < paranthes.Length; i++)
                {
                    if (isBalanced == false)
                    {
                        break;
                    }

                    for (int j = paranthes.Length - 1 - i; j >= i; j--)
                    {
                        //{ [ ( ) ] }
                        //0 1 2 3 4 5
                        if ((paranthes[i] == '[' || paranthes[i] == '{')
                            && paranthes[i] == (char)(paranthes[j] - 2))
                        {
                            break;
                        }
                        else if (paranthes[i] == '('
                            && paranthes[i] == (char)(paranthes[j] - 1))
                        {
                            break;
                        }
                        else if (paranthes[i] == paranthes[j]
                            && char.Equals(' ', paranthes[i])) // for space, ensuring no other chars besides space and (,[,{,},],)
                        {
                            break;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }

            }


            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
