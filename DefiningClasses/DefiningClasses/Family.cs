using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;
        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            if (!members.Contains(member))
            {

                members.Add(member);
            }
            else
            {
                Console.WriteLine($"Member {member} already exists");
            }
        }

        public void GetOldestMember()
        {
            Person oldestPerson = null;

            if (members.Count == 0)
            {
                Console.WriteLine("No members added to the Family!");
                return;
            }
            else
            {
                oldestPerson = members[0];
                foreach (var item in members)
                {
                    if (item.Age > oldestPerson.Age)
                    {
                        oldestPerson = item;
                    }
                }
            }

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }

    }
}
