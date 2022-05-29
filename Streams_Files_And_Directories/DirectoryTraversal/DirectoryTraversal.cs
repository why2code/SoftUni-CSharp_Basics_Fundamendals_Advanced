namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            //string reportFileName = @"..\Users\..\report.txt";
            string reportFileName = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, Dictionary<string, long>> traversedDirectoryDetails = new Dictionary<string, Dictionary<string, long>>();
            var dirDetails = new DirectoryInfo(inputFolderPath);
            var allFilesInDir = dirDetails.GetFiles("*", SearchOption.TopDirectoryOnly);
            foreach (var item in allFilesInDir)
            {
                string extension = item.Extension;
                string fileName = item.Name;
                long size = item.Length;

                if (!traversedDirectoryDetails.ContainsKey(extension))
                {
                    traversedDirectoryDetails.Add(extension, new Dictionary<string, long>());
                    traversedDirectoryDetails[extension][fileName] = size;
                }
                else
                {
                    if (!traversedDirectoryDetails[extension].ContainsKey(fileName))
                    {
                        traversedDirectoryDetails[extension][fileName] = size;
                    }
                    else
                    {
                        traversedDirectoryDetails[extension][fileName] += size;
                    }
                }
            }

            traversedDirectoryDetails.OrderBy(x => x.Value.Count).ThenByDescending(y => y.Value.OrderBy(y => y.Value)).ThenBy(x => x.Key);
            StringBuilder output = new StringBuilder();
            foreach (var key in traversedDirectoryDetails.Keys)
            {
                output.Append($"{key}");
                output.AppendLine();
                foreach (var file in traversedDirectoryDetails[key])
                {
                    string itemName = file.Key;
                    long size = file.Value;
                    output.Append($"--{itemName} - {size}kb");
                    output.AppendLine();
                }
            }

            return output.ToString();

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
        }
    }
}
