using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Booking
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokaz_Menu();
        }

        public static void Pokaz_Menu()
        {
            Console.WriteLine("Witam na stronie Booking");
            Console.WriteLine("MENU");
            Console.WriteLine("1. Polecane miejsca");
            Console.WriteLine("2. Aktualna promocja");
            Console.WriteLine("3. Rejestracja ");
            Console.WriteLine("4. Logowanie do systemu ");
            int wybor = int.Parse(Console.ReadLine());
            Menu.wybor(wybor);
            Console.ReadLine();
        }

    }

    class Menu
    {
        public static void wybor(int numer)
        {

            switch (numer)
            {
                case 1:
                    //Miejsca_podrozy.miejsca_p();
                    break;
                case 2:
                    //Promocja_lot.promocja();
                    break;
                case 3:
                    //Rejestracja.rejestracja();
                    break;
                case 4:
                    //Logowanie.logowanie();
                    break;
                default:
                    Program.Pokaz_Menu();
                    break;

            }
        }
    }
}

