using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Formularz
    {
        public static void Form()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Podaj miejsce wylotu");
            string miejsce_wylotu = Console.ReadLine();

            Console.WriteLine("Podaj cel podróży");
            string cel_podrozy = Console.ReadLine();

            Console.WriteLine("Podaj date podróży");
            string[] data_wylotu = Console.ReadLine().Split(':');

            Console.WriteLine("Podaj ilosc pasażerów");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());


            Console.WriteLine("Wybierz klase:");
            Console.WriteLine("1. klasa ekonomiczna");
            Console.WriteLine("2. klasa biznesowa");

            string klasa;
            int numer_kl = int.Parse(Console.ReadLine());

            if (numer_kl == 1)
            {
                klasa = "ekonomiczna";
            }
            else klasa = "biznesowa";
        }

        public static void Wybor_miejsca()
        {
            Console.WriteLine();
            string[,] tablica = new string[16, 6] {
            {"X" ,"A", "B","" ,"C", "D"}, {"1" ,"O", "O", "" , "O", "O"}, {"2" ,"O", "O","" ,"O", "O"}, {"3" ,"O", "O","" ,"O", "O"}, {"4" ,"O", "O", "","O", "O"},
            {"5" ,"O", "O", "", "O", "O"}, {"5" ,"O", "O", "" ,"O", "O"}, {"6" ,"O", "O","" ,"O", "O"}, {"7" ,"O", "O", "","O", "O"},{"8" ,"O", "O","" ,"O", "O"},{"9" ,"O", "O", "","O", "O"},
            {"10" ,"O", "O","" , "O", "O"},{"11" ,"O", "O", "" ,"O", "O"},{"12" ,"O", "O", "","O", "O"},{"13" ,"O", "O", "","O", "O"},{"14" ,"O", "O", "","O", "O"}
            };

            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    Console.Write(tablica[i, j] + "\t");
                }
                Console.WriteLine();
            }
            string[] wartosc_mierjsca = Console.ReadLine().Split(' ');

        }
    }
}
