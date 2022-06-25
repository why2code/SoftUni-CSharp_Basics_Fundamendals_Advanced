using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        //•	Name: string
        //•	NeededRenovators: int
        //•	Project: string

        public List<Renovator> Renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => Renovators.Count; 
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            string result = null;
            if (Renovators.Count >= NeededRenovators)
            {
                result = "Renovators are no more needed.";
                return result;
            }
            else
            {
                if (renovator.Name == null || renovator.Type == null
                    || renovator.Name == "" || renovator.Type == "")
                {
                    result = "Invalid renovator's information.";
                    return result;
                }

                if (renovator.Rate > 350)
                {
                    result = "Invalid renovator's rate.";
                    return result;
                }
            }

            result = $"Successfully added {renovator.Name} to the catalog.";
            Renovators.Add(renovator);
            return result;
        }


        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator personToRemove = Renovators.Find(x => x.Name == name);
                Renovators.Remove(personToRemove);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var toremove = Renovators.Where(x => x.Type == type).ToList();
            Renovators.RemoveAll(x => x.Type == type);
            return toremove.Count;
            //int removedRenovators = 0;
            //for (int i = 0; i < Renovators.Count; i++)
            //{
            //    if (Renovators[0].Type == type)
            //    {
            //        removedRenovators++;
            //        Renovators.Remove(Renovators[0]);
            //    }
            //}
            //return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = Renovators.First(x => x.Name == name);
                renovator.Hired = true;
                return renovator;
            }
            else
            {
                return null;
            }
        }


        public List<Renovator> PayRenovators(int days)
        {
            var workingRenovators = Renovators.Where(x => x.Days >= days).ToList();
            return workingRenovators;
        }

        public string Report()
        {
            var notWorkingRenovators = Renovators.Where(x => x.Hired == false).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in notWorkingRenovators)
            {
                sb.AppendLine(string.Join("", renovator));
            }
            return sb.ToString().TrimEnd();
        }

    }
}
