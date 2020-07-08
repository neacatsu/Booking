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
            Console.WriteLine("2. Aktualna promocja");
            Console.WriteLine("3. Rejestracja ");
            Console.WriteLine("4. Logowanie do systemu ");
            Console.Write("Twój wybór: ");
        }


        public static void Panel_log(bool wartosc, string login, string haslo)
        {
            if (wartosc) Console.WriteLine("Witaj użytkowniku " + login);
            else
            {
                Console.WriteLine("Błędny login lub hasło");
                string nowy_login = Podaj_login();
                string nowe_haslo = Podaj_haslo();
                if (Logowanie.Login(nowy_login) == true && Logowanie.Haslo(nowe_haslo) == true) Panel_log(true, nowy_login, nowe_haslo);
                else Panel_log(false, nowy_login, nowe_haslo);
            }
        }
        public static string Podaj_login()
        {
            Console.Write("Podaj login: ");
            return Console.ReadLine();
        }

        public static string Podaj_haslo()
        {
            Console.Write("Podaj haslo: ");
            return Console.ReadLine();
        }


        public static string[] Text(int ilosc_pasazerow) {

            string[] wartosc_miejsca = new string[ilosc_pasazerow * 2];
            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                Console.WriteLine("Miejsce dla pasazera"+i);
                wartosc_miejsca = Console.ReadLine().Split(' ');
            }
            return wartosc_miejsca;
        }
        public static void Wyswietl_miejsca(string[,] tablica_miejsc)
        {
            for (int i = 0; i < tablica_miejsc.GetLength(0); i++)
            {
                for (int j = 0; j < tablica_miejsc.GetLength(1); j++)
                {
                    Console.Write(tablica_miejsc[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void Form()
        {
            // POBIERANIE MIEJSCA WYLOTY
            var miejsce_enum = Enum.GetNames(typeof(Formularz.Miejsca)).Length;
            for (int i = 0; i < miejsce_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Miejsca)i);
            }
            Console.WriteLine("Podaj miejsce wylotu");
            var miejsce_wylotu = Console.ReadLine();

            // POBIERANIE CELU PODROZY
            var cel_enum = Enum.GetNames(typeof(Formularz.Cel)).Length;
            for (int i = 0; i < cel_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Cel)i);
            }
            Console.WriteLine("Podaj cel podróży");
            var cel_podrozy = Console.ReadLine();
            string cel = Rezerwacja.R_cel_podrozy(cel_podrozy);

            // POBIERANIE DATY PODROZY
            Console.WriteLine("Podaj date podróży (dd/mm/yyyy)");
            DateTime data_podrozy = Convert.ToDateTime(Console.ReadLine());
            while (data_podrozy < DateTime.Now)
                {
                    Console.Write("Błędna data, podaj prawidłową datę: ");
                    data_podrozy = Convert.ToDateTime(Console.ReadLine());
            }

            // POBIERANIE KLASY LOTU
            var klasa_enum = Enum.GetNames(typeof(Formularz.Klasa)).Length;
            for (int i = 0; i < klasa_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Klasa)i);
            }
            Console.WriteLine("Wybierz klase:");
            var klasa = Console.ReadLine();

            // POBIERANIE ILOSCI PASAZEROW
            Console.WriteLine("Podaj ilosc pasażerów");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());


            // SPOWYWANIE ICH WYBORU MIEJSC
            string[] wynik_miejsca = new string[ilosc_pasazerow * 2];
            string[] wartosc_miejsca = new string[ilosc_pasazerow * 2];
            string[,] tablica_miejsc = Wybor_miejsc.Odczyt_miejsc();
            if (Wybor_miejsc.Czy_pelny(tablica_miejsc) == false) Console.WriteLine("Obecnie samolot jest przepełniony, wpisz swoje wartości, a my udostępnimy Ci nowy samolot!");
            else Console.WriteLine("Obecne miejsca: ");
            Wyswietl_miejsca(tablica_miejsc);

            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                int j = i + 1;
                Console.Write("Wybierz miejsce dla " + j + " pasażera: ");
                string miejsce = Console.ReadLine();
                wynik_miejsca = Wybor_miejsc.Wartosc_miejsc(wartosc_miejsca, miejsce, j);
            }
            Console.WriteLine();

            // ZAMIANA MIEJSC
            if (Wybor_miejsc.Czy_pelny(tablica_miejsc) == false) tablica_miejsc = Wybor_miejsc.Zamiana_wartosci(tablica_miejsc, wynik_miejsca, ilosc_pasazerow);
            tablica_miejsc = Wybor_miejsc.Zamiana_wartosci(tablica_miejsc, wynik_miejsca, ilosc_pasazerow);
            Console.WriteLine("Miejsca po zarezerwowaniu: ");
            Wyswietl_miejsca(tablica_miejsc);
            
            Wybor_miejsc.Zapis_miejsc(tablica_miejsc);

            double cena = Rezerwacja.Rezerwacja_(cel, data_podrozy);
            //Rezerwacja.Re(cel, data_podrozy);
            Wynik(cena, miejsce_wylotu, cel_podrozy, data_podrozy, klasa, ilosc_pasazerow);
        }

        public static void Wynik(double cena,string miejsce_wylotu, string cel_wylotu, DateTime data_podrozy, string klasa, int ilosc_pasazerow)
        {
            Console.Clear();
            Console.WriteLine("REZERWACJA LOTU");
            Console.WriteLine("Twoje miejsce wylotu "+Rezerwacja.R_miejsce_wylotu(miejsce_wylotu));
            Console.WriteLine("Cel podróży "+Rezerwacja.R_cel_podrozy(cel_wylotu));
            Console.WriteLine("Cena za lot dla wszystkich "+cena * ilosc_pasazerow);
            Console.WriteLine("Data wylotu " +data_podrozy.ToString("dd/MM/yyyy"));
            Console.WriteLine("Klasa podróży " + Rezerwacja.R_klasa(klasa));
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
                    string login = Podaj_login();
                    string haslo = Podaj_haslo();
                    if (Logowanie.Login(login) == true && Logowanie.Haslo(haslo) == true) Panel_log(true, login, haslo);
                    else Panel_log(false, login, haslo);
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

