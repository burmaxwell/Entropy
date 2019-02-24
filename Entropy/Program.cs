using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Entropy
{
    class Program
    {
        static public string ToClearText(string text)
        {
            string ClearText= text.Replace(" ", string.Empty).Trim().ToLower();
            var matches = Regex.Matches(ClearText, @"[абвгдежзийклмнопрстуфхцчшщыьэюя]+").Cast<Match>().Select(i => i.Value).ToArray();
            ClearText = String.Join("", matches);
            return ClearText;
        }

        static public void MonogramFrequency(string text)
        {
            char[] Letters = text.ToCharArray();
            Letters = Letters.Where(v => v != ' ').ToArray();
            var distinctLetters = Letters.Distinct().ToArray();
            var n = Letters.GroupBy(v => v).Select(v => v.Count()).ToArray();
            int TextLength = Letters.Length;
            Console.WriteLine(TextLength);
            Console.WriteLine("\nВ файл входят символы:");
            for (int i = 0; i < distinctLetters.Length; i++)
                Console.WriteLine($"{distinctLetters[i]} - {(double)n[i]/(double)TextLength}");
        }

        static void Main(string[] args)
        {
            string DirtyText = File.ReadAllText(@"C:\Users\burlu\source\repos\Entropy\Encrypted.txt", Encoding.GetEncoding(1251));
            //Console.WriteLine("\t*******Чистый текст*******\n"+ ToClearText(DirtyText));
            string ClearText=ToClearText(DirtyText);
            MonogramFrequency(ClearText);
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();

        }
    }
}
