﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Threading;

namespace Booking
{
    class Program
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
                    Rejestracja.Rejestracja_();
                    Console.WriteLine("Zostałeś pomyślnie zarejestrowany");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Logowanie.Logowanie_();
                    break;
                case 4:
                    // Logowanie.Logowanie_ ();
                    break;
                default:
                    Console.Clear();
                    break;

            }
        }

    }

}

