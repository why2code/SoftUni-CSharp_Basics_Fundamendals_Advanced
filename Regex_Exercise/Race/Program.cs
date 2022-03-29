using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, int> validParticipantsWithTotalRun = new Dictionary<string, int>();

            string currentRunner = Console.ReadLine();
            //([A-Z]|[a-z]*)(\d*)
            string regPattern = @"([A-Z]|[a-z]*)(\d*)";
            while (currentRunner != "end of race")
            {
                Regex reg = new Regex(regPattern);
                var extractedRacerData = reg.Match(currentRunner);
                int currentRunnedTotal = 0;

                string runnerName = "";
                string digitsRunned = "";

                //Multiple matches from Group 1 and Group2 being concatenated (grouped) into single string
                while (extractedRacerData.Success)
                {
                    runnerName += extractedRacerData.Groups[1].Value;
                    digitsRunned += extractedRacerData.Groups[2].Value;
                    extractedRacerData = extractedRacerData.NextMatch();
                }

                if (participants.Contains(runnerName))
                {
                    foreach (char num in digitsRunned)
                    {
                        int valueRun = int.Parse(num.ToString());
                        currentRunnedTotal += valueRun;
                    }

                    if (validParticipantsWithTotalRun.ContainsKey(runnerName))
                    {
                        validParticipantsWithTotalRun[runnerName] += currentRunnedTotal;
                    }
                    else
                    {
                        validParticipantsWithTotalRun.Add(runnerName, currentRunnedTotal);
                    }
                }


                currentRunner = Console.ReadLine();
            }

            //Taking top3 and printing
            var sortedRunnersTop3 = validParticipantsWithTotalRun.OrderByDescending(x => x.Value).Take(3);
            List<string> names = new List<string>();
            foreach (var item in sortedRunnersTop3)
            {
                string runnerName = item.Key;
                names.Add(runnerName);
            }
            Console.WriteLine($"1st place: {names[0]}");
            Console.WriteLine($"2nd place: {names[1]}");
            Console.WriteLine($"3rd place: {names[2]}");



        }
    }
}
