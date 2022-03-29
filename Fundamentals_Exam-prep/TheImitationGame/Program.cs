using System;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string instructions = Console.ReadLine();
            while (instructions != "Decode")
            {
                string[] commandArgs = instructions.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = commandArgs[0];

                if (typeOfCommand == "Move")
                {
                    int lettersToMove = int.Parse(commandArgs[1]);
                    int lenghtOfMessage = encryptedMessage.Length;
                    if (!(lettersToMove <= encryptedMessage.Length))
                    {
                        instructions = Console.ReadLine();
                        continue;
                    }
                    string movingLetters = encryptedMessage.Substring(0, lettersToMove);
                    encryptedMessage = encryptedMessage.Remove(0, lettersToMove); //20 5 - 15
                    encryptedMessage = encryptedMessage.Insert(lenghtOfMessage - lettersToMove, movingLetters);
                }
                else if (typeOfCommand == "Insert")
                {
                    int indexToAdd = int.Parse(commandArgs[1]);
                    string messageToAdd = commandArgs[2];
                    if (!(indexToAdd >= 0 && indexToAdd <= encryptedMessage.Length))
                    {
                        instructions = Console.ReadLine();
                        continue;
                    }
                    encryptedMessage = encryptedMessage.Insert(indexToAdd, messageToAdd);
                }
                else //typeOfCommand == "ChangeAll"
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    encryptedMessage = ReplaceSubstring(encryptedMessage, substring, replacement);
                }


                instructions = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        static string ReplaceSubstring(string encryptedMessage, string substring, string replacement)
        {
            while (encryptedMessage.Contains(substring))
            {
                encryptedMessage = encryptedMessage.Replace(substring, replacement);
            }

            return encryptedMessage;
        }
    }
}
