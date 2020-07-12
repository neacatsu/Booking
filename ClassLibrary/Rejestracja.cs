using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;
using System.Globalization;

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

        public static bool Sprawdzanie_hasla(string wartosc_hasla)
        {
            if (wartosc_hasla.Length <= 8) return false;
            else if (wartosc_hasla.Any(ch => !Char.IsLetterOrDigit(ch))) return true; 
            return false;
        }
    }
}

            
           
