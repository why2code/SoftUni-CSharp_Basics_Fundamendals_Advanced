using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    internal class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            //Creating a set for storing last position of the invitations
            Dictionary<string, int> invitationsSet = new Dictionary<string, int>();


            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string firstCommType = commandArgs[0]; //to check for Add or Remove
                string secondCommType = commandArgs[1]; //to check for Starts or Ends or Contains or Lenght
                //char thirdParameter = char.Parse(commandArgs[2]); //applicable as string for all filters, except Lenght (req. int)

                Func<string, char, bool> checkForStartingLetter = (invitation, letter) => invitation.StartsWith(letter);
                Func<string, char, bool> checkForEndingLetter = (invitation, letter) => invitation.EndsWith(letter);
                Func<string, char, bool> checkForContainingLetter = (invitation, letter) => invitation.Contains(letter);

                if (firstCommType.StartsWith("Add"))
                {
                    if (secondCommType.StartsWith("Starts"))
                    {
                        char thirdParameter = char.Parse(commandArgs[2]); //applicable as string for all filters, except Lenght (req. int)
                        for (int i = 0; i < invitations.Count; i++)
                        {
                            string name = invitations[i];
                            if (checkForStartingLetter(name, thirdParameter))
                            {
                                int index = invitations.IndexOf(name);
                                invitations.Remove(name);
                                invitationsSet[name] = index; //storing current invitations state, assuming no exceptions
                            }
                        }

                    }
                    else if (secondCommType.StartsWith("Ends"))
                    {
                        char thirdParameter = char.Parse(commandArgs[2]); //applicable as string for all filters, except Lenght (req. int)

                        for (int i = 0; i < invitations.Count; i++)
                        {
                            string name = invitations[i];
                            if (checkForEndingLetter(name, thirdParameter))
                            {
                                int index = invitations.IndexOf(name);
                                invitations.Remove(name);
                                invitationsSet[name] = index; //storing current invitations state, assuming no exceptions
                            }
                        }
                    }
                    else if (secondCommType.StartsWith("Contains"))
                    {
                        string thirdParameter = commandArgs[2]; //applicable as string for all filters, except Lenght (req. int)

                        for (int i = 0; i < invitations.Count; i++)
                        {
                            string name = invitations[i];
                            if (name.Contains(thirdParameter))
                            {
                                int index = invitations.IndexOf(name);
                                invitations.Remove(name);
                                invitationsSet[name] = index; //storing current invitations state, assuming no exceptions
                            }
                        }
                    }
                    else if (secondCommType.StartsWith("Lenght"))
                    {
                        int lenghtThirdParameter = int.Parse(commandArgs[2]);
                        for (int i = 0; i < invitations.Count; i++)
                        {
                            string name = invitations[i];
                            if (name.Length == lenghtThirdParameter)
                            {
                                int index = invitations.IndexOf(name);
                                invitations.Remove(name);
                                invitationsSet[name] = index; //storing current invitations state, assuming no exceptions
                            }
                        }
                    }
                }
                else if (firstCommType.StartsWith("Remove"))
                {
                    if (secondCommType.StartsWith("Starts"))
                    {
                        char thirdParameter = char.Parse(commandArgs[2]); //applicable as string for all filters, except Lenght (req. int)

                        if (invitationsSet.Keys.Any(x => x.StartsWith(thirdParameter)))
                        {
                            string userToPushBack = string.Join("", invitationsSet.Keys.Where(x => x.StartsWith(thirdParameter)));
                            int indexToPush = invitationsSet[userToPushBack];
                            invitations.Insert(indexToPush, userToPushBack);
                            invitationsSet.Remove(userToPushBack);
                        }

                    }
                    else if (secondCommType.StartsWith("Ends"))
                    {
                        char thirdParameter = char.Parse(commandArgs[2]); //applicable as string for all filters, except Lenght (req. int)

                        if (invitationsSet.Keys.Any(x => x.EndsWith(thirdParameter)))
                        {
                            string userToPushBack = string.Join("", invitationsSet.Keys.Where(x => x.EndsWith(thirdParameter)));
                            int indexToPush = invitationsSet[userToPushBack];
                            invitations.Insert(indexToPush, userToPushBack);
                            invitationsSet.Remove(userToPushBack);
                        }

                    }
                    else if (secondCommType.StartsWith("Contains"))
                    {
                        string thirdParameter = commandArgs[2]; //applicable as string for all filters, except Lenght (req. int)

                        if (invitationsSet.Keys.Any(x => x.Contains(thirdParameter)))
                        {
                            string userToPushBack = string.Join("", invitationsSet.Keys.Where(x => x.Contains(thirdParameter)));
                            int indexToPush = invitationsSet[userToPushBack];
                            invitations.Insert(indexToPush, userToPushBack);
                            invitationsSet.Remove(userToPushBack);
                        }
                    }
                    else if (secondCommType.StartsWith("Lenght"))
                    {
                        int lenghtThirdParameter = int.Parse(commandArgs[2]);
                        if (invitationsSet.Keys.Any(x => x.Length == lenghtThirdParameter))
                        {
                            string userToPushBack = string.Join("", invitationsSet.Keys.Where(x => x.Length == lenghtThirdParameter));
                            int indexToPush = invitationsSet[userToPushBack];
                            invitations.Insert(indexToPush, userToPushBack);
                            invitationsSet.Remove(userToPushBack);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            //Final print, means we have reached "Print" command and exited the While loop
            foreach (var name in invitations)
            {
                Console.Write($"{name} ");
            }

        }
    }
}
