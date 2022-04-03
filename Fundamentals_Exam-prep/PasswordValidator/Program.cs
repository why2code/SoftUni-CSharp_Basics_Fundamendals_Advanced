using System;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalPassword = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Complete")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentCommand = commArgs[0];

                if (currentCommand == "Make")
                {
                    if (commArgs[1] == "Upper")
                    {
                        int indexToChange = int.Parse(commArgs[2]);
                        string letterChanged = originalPassword.Substring(indexToChange, 1);

                        originalPassword = originalPassword.Remove(indexToChange, 1);
                        originalPassword = originalPassword.Insert(indexToChange, letterChanged.ToUpper());
                        Console.WriteLine(originalPassword);
                    }
                    else if (commArgs[1] == "Lower")
                    {
                        int indexToChange = int.Parse(commArgs[2]);
                        string letterChanged = originalPassword.Substring(indexToChange, 1);

                        originalPassword = originalPassword.Remove(indexToChange, 1);
                        originalPassword = originalPassword.Insert(indexToChange, letterChanged.ToLower());
                        Console.WriteLine(originalPassword);
                    }

                }
                else if (currentCommand == "Insert")
                {
                    int indexToInsert = int.Parse(commArgs[1]);
                    string letterToInsert = commArgs[2];

                    if (indexToInsert >= 0 && indexToInsert < originalPassword.Length)
                    {
                        originalPassword = originalPassword.Insert(indexToInsert, letterToInsert);
                        Console.WriteLine(originalPassword);
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                }
                else if (currentCommand == "Replace")
                {
                    char replacementChar = (char.Parse(commArgs[1]));
                    int valueToAdd = int.Parse(commArgs[2]);

                    if (!originalPassword.Contains(replacementChar))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {

                        char c = replacementChar;
                        int r = valueToAdd;
                        c += (char)r;

                        while (originalPassword.Contains(replacementChar))
                        {
                            originalPassword = originalPassword.Replace(replacementChar, c);
                        }
                        Console.WriteLine(originalPassword);
                    }
                }
                else if (currentCommand == "Validation")
                {
                    if (originalPassword.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }

                    foreach (char letter in originalPassword)
                    {
                        if (!char.IsDigit(letter))
                        {
                            if (!char.IsLetter(letter))
                            {
                                if (letter != '_')
                                {
                                    Console.WriteLine("Password must consist only of letters, digits and _!");
                                    break;
                                }

                            }
                        }

                        ////&& !char.IsLetter(letter)
                        ////&& !char.IsSymbol('_'))
                        //{
                        //    Console.WriteLine("Password must consist only of letters, digits and _!");
                        //    //command = Console.ReadLine();
                        //    break;
                        //}



                    }


                    int counterUpperCases = 0;
                    foreach (char letter in originalPassword)
                    {
                        if (char.IsUpper(letter))
                        {
                            counterUpperCases++;
                        }
                    }
                    if (counterUpperCases == 0)
                    {

                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }


                    int counterLowerCases = 0;
                    foreach (char letter in originalPassword)
                    {
                        if (char.IsLower(letter))
                        {
                            counterLowerCases++;
                        }
                    }
                    if (counterLowerCases == 0)
                    {

                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }

                    int counterDigits = 0;
                    foreach (char letter in originalPassword)
                    {
                        if (char.IsDigit(letter))
                        {
                            counterDigits++;
                        }
                    }
                    if (counterDigits == 0)
                    {

                        Console.WriteLine("Password must consist at least one digit!");
                    }

                }
                else //invalid command
                {
                    command = Console.ReadLine();
                    continue;
                }


                command = Console.ReadLine();
            }
        }
    }
}
