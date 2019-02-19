using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entropy
{
    class Program
    {


        static void Main(string[] args)
        {
            string EncryptedFile = @"C:\Users\burlu\source\repos\Entropy\Encrypted.txt";
            try
            {
                Console.WriteLine("******считываем весь файл********");//
                using (StreamReader sr = new StreamReader(EncryptedFile))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
