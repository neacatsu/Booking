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


        public static void Form()
        {
            var miejsce_enum = Enum.GetNames(typeof(Formularz.Miejsca)).Length;
            for (int i = 0; i < miejsce_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Miejsca)i);
            }
            Console.WriteLine("Podaj miejsce wylotu");
            var miejsce_wylotu = Console.ReadLine();



            var cel_enum = Enum.GetNames(typeof(Formularz.Cel)).Length;
            for (int i = 0; i < cel_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Cel)i);
            }
            Console.WriteLine("Podaj cel podróży");
            var cel_podrozy = Console.ReadLine();

            Console.WriteLine("Podaj date podróży (dd/mm/yyyy)");
            DateTime data_podrozy = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Podaj ilosc pasażerów");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());


            var klasa_enum = Enum.GetNames(typeof(Formularz.Klasa)).Length;
            for (int i = 0; i < klasa_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Klasa)i);
            }
            Console.WriteLine("Wybierz klase:");
            var klasa = Console.ReadLine();

            Wybor_miejsc.Wybor_miejsc_(ilosc_pasazerow);
            Console.WriteLine(Rezerwacja.Rezerwacja_(miejsce_wylotu, cel_podrozy, data_podrozy, ilosc_pasazerow, klasa));


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
                    Console.Write("Podaj login: ");
                    string login = Console.ReadLine();
                    Console.Write("Podaj haslo: ");
                    string haslo = Console.ReadLine();
                    Logowanie.Logowanie_ (login, haslo);
                    panel_log(login, haslo);
                    Console.WriteLine();
                    Form();
                    break;
                default:
                    Console.Clear();
                    break;

            }
        }

    }

}

