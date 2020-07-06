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

        public static bool Login(string login)
        {
            Console.Clear();
            foreach (string linia in File.ReadLines(@"build.txt"))
            {
                if (linia == login) return true;
            }
            return false;
        }

        public static bool Haslo(string haslo)
        {
            Console.Clear();
            foreach (string linia in File.ReadLines(@"build.txt"))
            {
                if (linia == haslo) return true;
            }
            return false;
        }

    }
}
