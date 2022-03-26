using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string employeeToAdd = Console.ReadLine();
            while (employeeToAdd != "End")
            {
                string[] commArgs = employeeToAdd.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string companyName = commArgs[0].Trim();
                string employeeID = commArgs[1].Trim();

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>() { employeeID });
                }
                else
                {
                    if (companies[companyName].Contains(employeeID))
                    {
                        employeeToAdd = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        companies[companyName].Add(employeeID);
                    }
                }

                employeeToAdd = Console.ReadLine();
            }

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
