namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath);

            Directory.CreateDirectory(outputPath);
            string[] filesList = Directory.GetFiles(inputPath);
            foreach (var file in filesList)
            {
                string name = Path.GetFileName(file);
                string dirToCopyInto = Path.Combine(outputPath, name);
                File.Copy(name, dirToCopyInto);
            }

        }
    }
}
