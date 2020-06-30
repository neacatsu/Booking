using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;

namespace ClassLibrary
{
    public class Rejestracja
    {

        public class Dane_Logowania
        {
            public string Login { get; private set; }
            public string Haslo { get; private set; }
            

            public Dane_Logowania(string login, string haslo)
            {
                Login = login;
                Haslo = haslo;

            }
        }

        public static bool Sprawdzanie_hasla(string wartosc_hasla)
        {
            if (wartosc_hasla.Length <= 8) return false;
            else if (wartosc_hasla.Any(ch => Char.IsSymbol(ch))) return false;
            else return true;

        }

        public static bool Sprawdzanie_loginu(string wartosc_login)
        {
            foreach (string linia in File.ReadLines("build.txt"))
            {
                if (linia.Contains(wartosc_login)) return false;
            }
            return true;
        }

        public static bool Blad_loginu(bool wartosc)
        {
            if (wartosc == true) return true;
            return false;
        }

        public static string Login()
        {
            bool poprawny_login = false;
            string login = "";
            while (!poprawny_login)
            {
                login = Console.ReadLine();
                poprawny_login = Sprawdzanie_loginu(login);
                if (!poprawny_login) Blad_loginu(true);

            }
            return login;
        }

        public static string Haslo()
        {
            bool poprawne_haslo = false;
            string haslo = "";
            while (!poprawne_haslo)
            {
                haslo = Console.ReadLine();
                poprawne_haslo = Sprawdzanie_hasla(haslo);
               
            }
            return haslo;
        }

        
        public static void Rejestracja_()
        {
            List<Dane_Logowania> input = new List<Dane_Logowania>();
            input.Add(new Dane_Logowania(Login(), Haslo()));


            foreach(Dane_Logowania dane in input)
               using (var writer = File.AppendText("build.txt"))
               {
                    writer.WriteLine(dane.Login);
                    writer.WriteLine(dane.Haslo);
               }
        }
    }

}
    