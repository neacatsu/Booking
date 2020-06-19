using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    class Rejestracja
    {
        public static void Rejestracja_()
        {
            Console.Clear();
            Console.Write("Podaj nową nazwę użytkownika: ");
            List<String> input = new List<string>();
            input.Add(Console.ReadLine());
            Console.Write("Podaj hasło: ");
            input.Add(Console.ReadLine());

            List<List<string>> dane_logowania = new List<List<string>>();
            dane_logowania.Add(input);

            for (int i = 0; i < dane_logowania.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    using (var writer = File.AppendText("build.txt"))
                    {
                        writer.WriteLine(dane_logowania[i][j]);
                    }
                }
            }
        }
    }
}
