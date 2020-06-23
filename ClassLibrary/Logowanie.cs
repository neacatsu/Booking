using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Logowanie
    {
        public static void Logowanie_()
        {
            Console.Clear();
            Console.Write("Login:");
            string aktualny_login = Console.ReadLine();
            Console.Write("Hasło:");
            string aktualne_haslo = Console.ReadLine();

            string sciezka = @"build.txt";
            string wiersze = File.ReadAllText(sciezka);
            string[] tab = new string[] { };
            tab = wiersze.Split('\n');

            /*for(int i = 0; i < tab.Length; i += 2)
            {
                if (tab[i] == aktualny_login)
                {
                    if (aktualne_haslo==tab[i+1])
                    {
                        Console.WriteLine("Witaj " + tab[i]);
                    }
                    else
                    {
                        Console.WriteLine("Błędne hasło");
                        Console.WriteLine("Podaj prawidłowe hasło");
                        aktualne_haslo = Console.ReadLine();

                    }
                    
                }
               
            } */

            Console.ReadLine();
            

 
           
        }

    }
}
