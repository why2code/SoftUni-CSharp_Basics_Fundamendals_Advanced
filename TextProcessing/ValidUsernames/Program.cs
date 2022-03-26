using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> validUsers = new List<string>();

            foreach (var user in usernames)
            {
                if (user.Length >= 3 && user.Length <= 16)
                {
                    if (user.All(Char.IsLetterOrDigit)
                        || user.Contains('-') && user.All(Char.IsLetterOrDigit)
                        || user.Contains('_') && user.All(Char.IsLetterOrDigit)
                        || user.Contains('_') && user.Contains('-')
                        || user.Contains('_')
                        || user.Contains('-'))
                    {
                        validUsers.Add(user);

                    }

                    //if (user.All(c => Char.IsLetterOrDigit(c) || c == ' ' || c == '_' || c == '-'))
                    //{
                    //    validUsers.Add(user);
                    //}

                }
            }

            foreach (var user in validUsers)
            {
                Console.WriteLine($"{user}");
            }
        }
    }
}
