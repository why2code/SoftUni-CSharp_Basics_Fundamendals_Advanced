namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = "../../../../Resources/text.txt";
            string outputFilePath = @"../../../output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] inputs = File.ReadAllLines(inputFilePath);
            int lettersCounter = 0;
            int punctioationMarksCounter = 0;
            string[] output = new string[inputs.Length];

            for (int i = 1; i <= inputs.Length; i++)
            {
                foreach (var ch in inputs[i - 1])
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCounter++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        punctioationMarksCounter++;
                    }
                }
                output[i - 1] = ($"Line {i}: " + inputs[i - 1] + $" ({lettersCounter})({punctioationMarksCounter})").ToString();
                lettersCounter = 0;
                punctioationMarksCounter = 0;
            }

            File.WriteAllLines(outputFilePath, output);

        }
    }
}
