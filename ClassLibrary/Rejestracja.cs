using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;


namespace ClassLibrary
{
    public class Rejestracja
    {
        static bool IsSymbol(char c)
        {
            return c > 32 && c < 127;
        }


        public static string Sprawdzanie_hasla(string wartosc_hasla)
        {
                      
            if (wartosc_hasla.Length <= 8) { 
            
               throw new ArgumentException("Hasło jest za krótkie, podaj nowe hasło");
                
            }
            else if (wartosc_hasla.Any(ch => Char.IsSymbol(ch)))
            {
                throw new ArgumentException("Hasło nie posiada znaku specjalnego, podaj nowe hasło");
                
            } 
            else 
            {
                return "true";
            }
            
        }


        public static void Rejestracja_()
        {
            Console.Clear();
            Console.Write("Podaj nową nazwę użytkownika: ");
            List<String> input = new List<string>();
            input.Add(Console.ReadLine());
            Console.Write("Podaj hasło: ");
            string wartosc_hasla = Console.ReadLine();

            if (Sprawdzanie_hasla(wartosc_hasla) == "true")
            {
                input.Add(wartosc_hasla);
            }
            input.Add(Sprawdzanie_hasla(wartosc_hasla));




            List<List<string>> dane_logowania = new List<List<string>>();
            dane_logowania.Add(input);

            for (int i = 0; i < dane_logowania.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
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
