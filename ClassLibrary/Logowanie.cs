using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace ClassLibrary
{
    public class Logowanie
    {

        public static bool Logowanie_(string login, string haslo)
        {
            string a_login = login;
            string a_haslo = haslo;
            string sciezka = @"build.txt";
            string[] tab = File.ReadAllLines(sciezka);

            foreach (string linia in File.ReadLines("build.txt"))
            {
                if (linia.Contains(a_login)) return true;
                
            }
            return false;
        }

    }
}
