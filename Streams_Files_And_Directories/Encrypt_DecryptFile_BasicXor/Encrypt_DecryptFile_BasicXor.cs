namespace Encrypt_DecryptFile_BasicXor
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"../../../../Resources/copyMe.png";
            string outputFilePath = @"../../../Encrypted-copy.png";
            string outputFileDecrypted = @"../../../Decrypted-copy.png";

            EncryptFile(inputFilePath, outputFilePath);
            DecryptFile(outputFilePath, outputFileDecrypted);

        }

        public static void EncryptFile(string inputFilePath, string outputFilePath)
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

                        const byte keyForEncryption = 135;

                        //Encrypting
                        for (int i = 0; i < dataRead; i++)
                            buff[i] = (byte)(buff[i] ^ keyForEncryption);
                        output.Write(buff, 0, dataRead);


                    }

                }

            }
                               

        }


        public static void DecryptFile(string outputFilePath, string outputFileDecrypted)
        {

            using (var input = new FileStream(outputFilePath, FileMode.Open))
            {
                using (var output = new FileStream(outputFileDecrypted, FileMode.Create))
                {
                    var buff = new Byte[1024];
                    while (true)
                    {

                        var dataRead = input.Read(buff, 0, buff.Length);
                        if (dataRead == 0)
                            break;

                        const byte keyForEncryption = 135;

                        //Decrypting
                        for (int i = 0; i < dataRead; i++)
                            buff[i] = (byte)(buff[i] ^ keyForEncryption);
                        output.Write(buff, 0, dataRead);


                    }

                }

            }


        }




    }
}

