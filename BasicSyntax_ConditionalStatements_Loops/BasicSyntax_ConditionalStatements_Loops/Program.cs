using System;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string userName = Console.ReadLine();
            string userPass = "";

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                userPass += userName[i];
            }

            //4 attemnts for password check
            for (int i = 1; i <= 4; i++)
            {
                string providedPasswordByUser = Console.ReadLine();
                if (providedPasswordByUser == userPass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }

                if (i < 4)
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {userName} blocked!");
                }

            }


        }
    }
}
