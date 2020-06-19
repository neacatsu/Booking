using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Logowanie
    {
        public static void Logowanie_()
        {
            Console.Clear();
            Console.Write("Login:");
            string aktualny_login = Console.ReadLine();
            Console.Write("Hasło:");
            string aktualne_haslo = Console.ReadLine();

            Console.WriteLine("Witaj " + aktualny_login);
            Formularz.Form();
            Formularz.Wybor_miejsca();
        }

    }
}
