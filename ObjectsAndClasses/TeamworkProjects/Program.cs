using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class StudentTeam
    {
        public StudentTeam(string teamName, string teamCreator)
        {
            this.TeamName = teamName;
            this.TeamCreator = teamCreator;
            this.Members = new List<string>();
        }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
        public string TeamCreator { get; set; }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<StudentTeam> teams = new List<StudentTeam>();

            //creating initial teams
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] creatingTeams = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string creatorName = creatingTeams[0];
                string teamName = creatingTeams[1];

                if (!DoesTeamOrCreatorAlreadyExist(teams, teamName, creatorName))
                {
                    teams.Add(new StudentTeam(teamName, creatorName));
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
            }

            //Adding joiners to the teams already created
            string newJoiners = Console.ReadLine();
            while (newJoiners != "end of assignment")
            {
                string[] creatingJoiners = newJoiners.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string memberName = creatingJoiners[0];
                string teamToJoin = creatingJoiners[1];

                if (TeamExists(teams, teamToJoin) && !(MemberExists(teams, memberName, teamToJoin)))
                {
                    teams.Add(new StudentTeam(teamToJoin, memberName));

                }


                newJoiners = Console.ReadLine();
            }



            //grouping different teams by TeamName and adding students into the Members List
            teams.Sort((a, b) => a.TeamName.CompareTo(b.TeamName));
            for (int i = 0; i < teams.Count - 1; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    teams[i].Members.Add(teams[i].TeamCreator.ToString());

                }

                if (teams[i].TeamName == teams[i + 1].TeamName)
                {
                    teams[i].Members.Add(teams[i + 1].TeamCreator.ToString());
                    teams.RemoveAt(i + 1);
                    i--;
                }

            }


            //Taking out Student Teams to disband (with creator only)
            List<StudentTeam> teamsWithZeroMembers = new List<StudentTeam>();

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count <= 1) //captures teams with no matching other TeamName, hence 1 member only
                {
                    teamsWithZeroMembers.Add(teams[i]);
                    teams.Remove(teams[i]);
                    i--;
                }
            }


            //Final sorting and printout of the data
            //Valid teams printout
            teams.Sort((a, b) => a.TeamName.CompareTo(b.TeamName));
            teams.Sort((x, y) => y.Members.Count.CompareTo(x.Members.Count));

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{teams[i].TeamName}");
                Console.WriteLine($"- {teams[i].TeamCreator}");

                teams[i].Members.RemoveAt(0);
                SortMembers(teams[i].Members);
                for (int j = 0; j < teams[i].Members.Count; j++)
                {
                    Console.WriteLine($"-- {teams[i].Members[j].ToString()}");
                }
            }


            //Disbanded teams printout
            Console.WriteLine("Teams to disband:");
            teamsWithZeroMembers.Sort((a, b) => a.TeamName.CompareTo(b.TeamName));
            if (teamsWithZeroMembers.Count > 0)
            {
                foreach (var team in teamsWithZeroMembers)
                {
                    Console.WriteLine($"{team.TeamName}");
                }
            }

        }

        static bool DoesTeamOrCreatorAlreadyExist(List<StudentTeam> teams, string teamName, string creatorName)
        {
            bool exist = false;
            if (teams.Exists(x => x.TeamName == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                exist = true;
            }

            if (teams.Exists(z => z.TeamCreator == creatorName))
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
                exist = true;
            }
            return exist;
        }

        static bool TeamExists(List<StudentTeam> teams, string teamName)
        {
            bool exists = false;
            if (teams.Exists(x => x.TeamName == teamName))
            {
                exists = true;
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist!");
            }
            return exists;
        }

        static bool MemberExists(List<StudentTeam> teams, string teamMember, string teamName)
        {
            bool exists = false;
            if (teams.Exists(x => x.TeamCreator == teamMember))
            {
                exists = true;
                Console.WriteLine($"Member {teamMember} cannot join team {teamName}!");
            }
            return exists;
        }

        static void SortMembers(List<string> members)
        {
            members.Sort((a, b) => a.CompareTo(b));
        }
    }
}
