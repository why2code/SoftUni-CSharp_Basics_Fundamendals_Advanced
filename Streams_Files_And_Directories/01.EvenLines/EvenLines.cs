namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"../../../../Resources/text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));

        }

        public static string ProcessLines(string inputFilePath)
        {
            var readStr = new StreamReader(inputFilePath);
            var singleText = new StringBuilder();
            var finalText = new StringBuilder();

            string lineText = readStr.ReadLine();
            int counter = 0;

            using (readStr)
            {
                while (lineText != null)
                {
                   
                    if (counter == 0 || counter % 2 == 0)
                    {
                        foreach (var ch in lineText)
                        {
                            if (ch.ToString() == "-"
                                || ch.ToString() == ","
                                || ch.ToString() == "."
                                || ch.ToString() == "!"
                                || ch.ToString() == "?")
                            {
                                singleText.Append('@');
                                //lineText = lineText.Replace(ch, '@');
                            }
                            else
                            {
                                singleText.Append(ch);
                            }
                           
                        }

                        lineText = singleText.ToString();
                        lineText = string.Join(" ", lineText.Split().Reverse());
                        finalText.Append(lineText);
                        finalText.AppendLine();

                        //lineText = string.Join(" ", lineText.Split().Reverse());
                        //lineText = lineText + Environment.NewLine;
                    }

                    counter++;
                    singleText.Clear();
                    lineText = readStr.ReadLine();

                }

                return finalText.ToString();

            }
        }
    }
}
