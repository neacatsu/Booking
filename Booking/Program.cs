﻿using System;
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
                int number = int.TryParse(wybor, out _) == true ? int.Parse(wybor) : 9;
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
            Console.Write("Twój wybór: ");
        }

        public static void Rejestracja_(string login, string haslo)
        {
            while (!Rejestracja.Sprawdzanie_loginu(login))
            {
                Console.Write("Podaj nowy login: ");
                login = Rejestracja_login(Console.ReadLine());
            }

            while (!Rejestracja.Sprawdzanie_hasla(haslo))
            {
                Console.Write("Podaj nowe hasło: ");
                haslo = Rejestracja_haslo(Console.ReadLine());
            }

            List<Rejestracja.Dane_Logowania> input = new List<Rejestracja.Dane_Logowania>
            {
                new Rejestracja.Dane_Logowania(login, haslo)
            };

            foreach (Rejestracja.Dane_Logowania dane in input)
            {
                using (var writer = File.AppendText("build.txt"))
                {
                    writer.WriteLine(dane.Login);
                    writer.WriteLine(dane.Haslo);
                }
            }
        }

        public static string Rejestracja_login(string login)
        {
            bool poprawny_login = false;

            while (!poprawny_login)
            {
                poprawny_login = Rejestracja.Sprawdzanie_loginu(login);
                if (!poprawny_login)
                {
                    poprawny_login = Rejestracja.Blad_loginu(true);
                }
            }
            return login;
        }

        public static string Rejestracja_haslo(string haslo)
        {
            bool poprawne_haslo = false;

            while (!poprawne_haslo)
            {
                poprawne_haslo = Rejestracja.Sprawdzanie_hasla(haslo);
                if (!poprawne_haslo)
                    poprawne_haslo = Rejestracja.Blad_loginu(true);
            }
            return haslo;
        }
        public static void Panel_log(bool wartosc, string login, string haslo)
        {
            if (wartosc)
            {
                Console.Write("Witaj użytkowniku ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(login);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
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

        public static void Wyswietl_nowe(string[,] tablica_miejsc, string[] wartosci_miejsc)
        {
            int k = 0;
            bool nie_bylo = true;
            for (int i = 0; i < tablica_miejsc.GetLength(0); i++)
            {
                for (int j = 0; j < tablica_miejsc.GetLength(1); j++)
                {
                    int index_poziom = Wybor_miejsc.Index_poziom(wartosci_miejsc[k]);
                    int index_pion = int.Parse(wartosci_miejsc[k + 1]);

                    if (index_pion == i && index_poziom == j && nie_bylo)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(tablica_miejsc[index_pion, index_poziom] + "\t");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (k + 2 < wartosci_miejsc.Length) k += 2;
                        else nie_bylo = false;
                    }
                    else Console.Write(tablica_miejsc[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static DateTime Do_daty(string data)
        {
            string[] liczby = data.Split(data[2]);
            if (int.Parse(liczby[0]) > 31 || int.Parse(liczby[1]) > 12 || int.Parse(liczby[2]) < DateTime.Now.Year) return DateTime.Now;
            DateTime nowa_data = new DateTime(int.Parse(liczby[2]), int.Parse(liczby[1]), int.Parse(liczby[0]));
            return nowa_data;
        }

        public static string Zamiana_miejsc(string fraza)
        {
            string zmieniona_fraza = new string(fraza.ToCharArray().Reverse().ToArray());
            return zmieniona_fraza;
        }

        public static void Form()
        {
            // POBIERANIE MIEJSCA WYLOTY
            Console.WriteLine("Dostępne miejsca wylotu: ");
            var miejsce_enum = Enum.GetNames(typeof(Formularz.Miejsca)).Length;
            for (int i = 0; i < miejsce_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Miejsca)i);
            }
            Console.Write("Podaj miejsce wylotu: ");
            var miejsce_wylotu = Console.ReadLine();
            Console.WriteLine();
            while (!Int32.TryParse(miejsce_wylotu, out _) && !Enum.IsDefined(typeof(Formularz.Miejsca), miejsce_wylotu.ToString()))
            {
                Console.Write("Podana wartość jest nieprawdłowa. Proszę spróbowac ponownie: ");
                miejsce_wylotu = Console.ReadLine();
            }

            // POBIERANIE CELU PODROZY
            Console.WriteLine("Dostępne miejsca podróży: ");
            var cel_enum = Enum.GetNames(typeof(Formularz.Cel)).Length;
            for (int i = 0; i < cel_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Cel)i);
            }
            Console.Write("Podaj cel podróży: ");
            var cel_podrozy = Console.ReadLine();
            string cel = Rezerwacja.R_cel_podrozy(cel_podrozy);
            Console.WriteLine();

            while (!Int32.TryParse(cel_podrozy, out _) && !Enum.IsDefined(typeof(Formularz.Cel), cel_podrozy.ToString()))
            {
                Console.Write("Podana wartość jest nieprawdłowa. Proszę spróbowac ponownie: ");
                cel_podrozy = Console.ReadLine();
            }

            // POBIERANIE KLASY LOTU
            Console.WriteLine("Dostępne klasy lotu: ");
            var klasa_enum = Enum.GetNames(typeof(Formularz.Klasa)).Length;
            for (int i = 0; i < klasa_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Formularz.Klasa)i);
            }
            Console.Write("Wybierz klase: ");
            var klasa = Console.ReadLine();
            Console.WriteLine();

            while (!Int32.TryParse(klasa, out _) && !Enum.IsDefined(typeof(Formularz.Klasa), klasa.ToString()))
            {
                Console.Write("Podana wartość jest nieprawdłowa. Proszę spróbowac ponownie: ");
                klasa = Console.ReadLine();
            }

            // POBIERANIE DATY PODROZY
            Console.Write("Podaj date podróży w formacie dd/mm/yyyy: ");
            string data = Console.ReadLine();
            char[] znaki = new char[] { '.', '/', ':' };
            while ((!data.Contains(znaki[0]) && !data.Contains(znaki[1]) && !data.Contains(znaki[2])) || data.Length != 10)
            {
                Console.Write("Podana data jest nieprawidłowa. Podaj jeszcze raz: ");
                data = Console.ReadLine();
            }

            // KONWERTOWANIE STRINGA NA DATE
            DateTime data_podrozy = Do_daty(data);
            while (data_podrozy <= DateTime.Now)
            {
                Console.Write("Błędna data, podaj prawidłową datę: ");
                data_podrozy = Convert.ToDateTime(Console.ReadLine());
            }
            Console.WriteLine();

            // POBIERANIE ILOSCI PASAZEROW
            Console.Write("Podaj ilosc pasażerów: ");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // SPRAWDZANIE SAMOLOTU I WYŚWIETLANIE GO
            string[] wynik_miejsca = new string[ilosc_pasazerow * 2];
            string[] wartosc_miejsca = new string[ilosc_pasazerow * 2];
            string[,] tablica_miejsc = Wybor_miejsc.Odczyt_miejsc();
            if (Wybor_miejsc.Czy_pelny(tablica_miejsc) == false) Console.WriteLine("Obecnie samolot jest przepełniony, wpisz swoje wartości, a my udostępnimy Ci nowy samolot!");
            else Console.WriteLine("Obecne miejsca: ");
            Wyswietl_miejsca(tablica_miejsc);

            //POBIERANIE WARTOŚĆI MIEJSC
            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                int j = i + 1;
                Console.Write("Wybierz miejsce dla " + j + " pasażera: ");
                string miejsce = Console.ReadLine().ToUpper();
                string pierwszy_znak = miejsce[0].ToString();
                if (Int32.TryParse(pierwszy_znak, out _)) miejsce = Zamiana_miejsc(miejsce);
                while (miejsce.Length < 2 || miejsce.Length > 3 || Wybor_miejsc.Czy_zajete(miejsce, tablica_miejsc) == false)
                {
                    Console.Write("Podano zajęte, bądź nieistniejące miejsce. Prosze podać jeszcze raz: ");
                    miejsce = Console.ReadLine().ToUpper();
                    if (Int32.TryParse(pierwszy_znak, out _)) miejsce = Zamiana_miejsc(miejsce);
                }
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
            Wynik(cena, miejsce_wylotu, cel_podrozy, data_podrozy, klasa, ilosc_pasazerow,  tablica_miejsc, wynik_miejsca);
            Console.Clear();
        }

        public static void Wynik(double cena,string miejsce_wylotu, string cel_wylotu, DateTime data_podrozy, string klasa, int ilosc_pasazerow, string[,] tablica_miejsc, string[] wartosc_miejsc)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("REZERWACJA LOTU");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Twoje miejsce wylotu "+Rezerwacja.R_miejsce_wylotu(miejsce_wylotu));
            Console.WriteLine("Cel podróży "+Rezerwacja.R_cel_podrozy(cel_wylotu));
            Console.WriteLine("Cena za lot dla wszystkich pasażerów "+cena * ilosc_pasazerow + " zł");
            Console.WriteLine("Data wylotu " +data_podrozy.ToString("dd/MM/yyyy"));
            Console.WriteLine("Klasa podróży " + Rezerwacja.R_klasa(klasa));
            Console.WriteLine();
            Console.WriteLine("Zarezerwowane miejsca: ");
            Wyswietl_nowe(tablica_miejsc, wartosc_miejsc);
            Console.WriteLine("Prosze nacisnac  enter, aby kontynuowac...");
            Console.ReadLine();
        }

        public static void Wybor_menu(int numer)
        {
            Console.Clear();
            switch (numer)
            {
                case 1:
                    Console.WriteLine(Miejsca_podrozy.Miejsca_p());
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Write("Obecna promocja na loty: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Promocja_lot.Promocja());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 3:
                    Console.Write("Podaj login, musi on posiadać conajmniej 8 znaków: ");
                    string nowy_login = Console.ReadLine();
                    Console.Write("Podaj hasło, Twoje hasło musi zawierać conajmniej 8 znaków w tym jeden znak specjalny: ");
                    string nowe_haslo = Console.ReadLine();
                    Rejestracja_(nowy_login, nowe_haslo);
                    Console.WriteLine("Zostałeś pomyślnie zarejestrowany");
                    Console.WriteLine("\nNaciśnij enter aby kontynuować... ");
                    Console.ReadLine();
                    break;
                case 4:
                    string login = Podaj_login();
                    string haslo = Podaj_haslo();
                    if (Logowanie.Login(login) == true && Logowanie.Haslo(haslo) == true) Panel_log(true, login, haslo);
                    else Panel_log(false, login, haslo);
                    Console.WriteLine();
                    Form();
                    break;
                default:
                    break;

            }
        }

    }

}

