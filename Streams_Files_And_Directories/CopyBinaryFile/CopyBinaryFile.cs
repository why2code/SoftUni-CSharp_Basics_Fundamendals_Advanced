namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"../../../../Resources/copyMe.png";
            string outputFilePath = @"../../../copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var input = new FileStream(inputFilePath, FileMode.Open))
            {
                using (var output = new FileStream(outputFilePath, FileMode.Create))
                {
                    var buff = new Byte[1024];
                    while (true)
                    {

                        var dataRead = input.Read(buff, 0, buff.Length);
                        if (dataRead == 0)
                            break;
                        output.Write(buff, 0, dataRead);
                    }

                }

            }
        }
    }
}
