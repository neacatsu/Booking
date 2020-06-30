using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Threading;
using System.IO;

namespace Booking
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                Pokaz_menu();
                string wybor = Console.ReadLine();
                int number;
                if (int.TryParse(wybor, out number) == true)
                {
                    number = int.Parse(wybor);
                }
                else
                {
                    number = 9;
                }
                Wybor_menu(number);
            }
        }

        public static void Pokaz_menu()
        {
            Console.WriteLine("Witamy na stronie Booking");
            Console.WriteLine("MENU");
            Console.WriteLine("1. Polecane miejsca");
            Console.WriteLine("2. Aktualna promocja");
            Console.WriteLine("3. Rejestracja ");
            Console.WriteLine("4. Logowanie do systemu ");
        }


        public static void panel_log(string login, string haslo)
        {
            if(Logowanie.Logowanie_(login, haslo) == true)
            {
                Console.WriteLine("Witaj użytkowniku " + login);
            }
            else
            {
                Console.WriteLine("Błędny login lub hasło");
                Logowanie.Logowanie_(login, haslo);
            }
        }


        public static string[] text(int ilosc_pasazerow) {

            string[] wartosc_miejsca = new string[ilosc_pasazerow * 2];
            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                Console.WriteLine("Miejsce dla pasazera"+i);
                wartosc_miejsca = Console.ReadLine().Split(' ');
            }
            return wartosc_miejsca;
        }




        public static void Wybor_menu(int numer)
        {

            switch (numer)
            {
                case 1:
                    Console.WriteLine(Miejsca_podrozy.Miejsca_p());
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Obecna promocja na loty: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Promocja_lot.Promocja()+" zł");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Podaj login: ");
                    Rejestracja.Rejestracja_();
                    Console.WriteLine("Podaj hasło: ");
                    Console.WriteLine("Zostałeś pomyślnie zarejestrowany");              
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Podaj login");
                    string login = Console.ReadLine();
                    Console.WriteLine("Podaj haslo");
                    string haslo = Console.ReadLine();
                    Logowanie.Logowanie_ (login, haslo);
                    panel_log(login, haslo);
                    Formularz.Form();
                    break;
                default:
                    Console.Clear();
                    break;

            }
        }

    }

}

