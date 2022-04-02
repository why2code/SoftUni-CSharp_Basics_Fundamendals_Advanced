using System;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalPassword = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string typeOfCommand = commArgs[0];
                if (typeOfCommand == "TakeOdd")
                {
                    string tempPass = null;
                    for (int i = 1; i <= originalPassword.Length - 1; i += 2)
                    {
                        tempPass += originalPassword[i];
                    }
                    originalPassword = tempPass;
                    Console.WriteLine(originalPassword);
                }
                else if (typeOfCommand == "Cut")
                {
                    int index = int.Parse(commArgs[1]);
                    int lenght = int.Parse(commArgs[2]);
                    string textToRemove = originalPassword.Substring(index, lenght);
                    int textIndex = originalPassword.IndexOf(textToRemove);
                    originalPassword = originalPassword.Remove(textIndex, textToRemove.Length);
                    Console.WriteLine(originalPassword);
                }
                else if (typeOfCommand == "Substitute")
                {
                    string searchedSubstringForReplacement = commArgs[1];
                    string newReplacementSubstring = commArgs[2];

                    if (originalPassword.Contains(searchedSubstringForReplacement))
                    {
                        while (originalPassword.Contains(searchedSubstringForReplacement))
                        {
                            //int replacementIndex = originalPassword.IndexOf(searchedSubstringForReplacement);
                            originalPassword = originalPassword.Replace(searchedSubstringForReplacement, newReplacementSubstring);
                            Console.WriteLine(originalPassword);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {originalPassword}");
        }
    }
}
