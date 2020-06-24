using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    public class Logowanie
    {
        public static string[] Szukanie(string[] tab1, string login, string haslo)
        {
            List<string> lista = new List<string>();
            int i = 0;
            while (lista.Count == 0 && i < tab1.Length - 1)
            {
                string pobrany_login = tab1[i];
                string pobrane_haslo = tab1[i + 1];
                if (pobrany_login==login && pobrane_haslo==haslo)
                {
                    lista.Add(pobrany_login);
                    lista.Add(pobrane_haslo);
                    Console.Clear();
                    Console.WriteLine("Witaj użytkowniku "+ pobrany_login);
                    Formularz.Form();
                }
               
                i += 2;
            }

            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Podany login lub hasło nie istnieje");
                Console.Write("Login: ");
                string nowy_login = Console.ReadLine();
                Console.Write("Haslo: ");
                string nowe_haslo = Console.ReadLine();
                Szukanie(tab1, nowy_login, nowe_haslo);
            }

            string[] tab2 = lista.ToArray();
            return tab2;
        }

        public static void Logowanie_()
        {
            Console.Clear();
            Console.Write("Login: ");
            string aktualny_login = Console.ReadLine();
            Console.Write("Hasło: ");
            string aktualne_haslo = Console.ReadLine();

            string sciezka = @"build.txt";
            string[] tab = File.ReadAllLines(sciezka);
            string[] tab_wynik = Szukanie(tab, aktualny_login, aktualne_haslo);


               

 
           
        }

    }
}
