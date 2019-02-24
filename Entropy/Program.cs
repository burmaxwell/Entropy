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
        static public string WriteText(string file)
        {
            Console.WriteLine("\t******Cчитываем весь файл*******\n");
            StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1251));//кодировка Windows-1251
            return sr.ReadToEnd();
        }
        static void Main(string[] args)
        {
            string EncryptedFile = @"C:\Users\burlu\source\repos\Entropy\Encrypted.txt";
            Console.WriteLine(WriteText(EncryptedFile));

            char[] Letters = File.ReadAllText(@"C:\Users\burlu\source\repos\Entropy\Encrypted.txt", Encoding.GetEncoding(1251)).Where(v => v != ' ').ToArray();//записываем символы (кроме пробелов) в массив --->получаем сплошную строку 
            var distinctLetters = Letters.Distinct().ToArray();//возвращаем неповторяющиеся буквы строки 
            Console.WriteLine("\n \t******Редаченый текст******");
            Console.WriteLine(Letters);
            var n = Letters.GroupBy(v => v).Select(v => v.Count()).ToArray();//массивы различных символов и их количества
            Console.WriteLine($"\nВ файл входят символы:\n{String.Join(Environment.NewLine, distinctLetters)}");//выводим различные символы

            Console.WriteLine("\nВ файл входят символы:");
            for (int i = 0; i < distinctLetters.Length; i++)
                Console.WriteLine($"{distinctLetters[i]} - {n[i]}");//выводим различные символы и их количество


            

            Console.ReadKey();
            
        }
    }
}
