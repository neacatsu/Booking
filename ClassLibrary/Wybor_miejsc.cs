using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    public class Wybor_miejsc
    {
        public static void Wybor_miejsc_(int ilosc_pasazerow)
        {
            string[,] tablica_miejsc = new string[16, 6];
            String wejscie = File.ReadAllText("wyb_m.txt");
            int a = 0;
            int b = 0;
            foreach (var rzad in wejscie.Split('\n'))
            {
                b = 0;
                foreach (var kolumna in rzad.Trim().Split(' '))
                {
                    tablica_miejsc[a, b] = kolumna.Trim();
                    b++;
                }
                a++;
            }


            for (int i = 0; i < tablica_miejsc.GetLength(0); i++)
            {
                for (int j = 0; j < tablica_miejsc.GetLength(1); j++)
                {
                    Console.Write(tablica_miejsc[i, j] + "\t");
                }
                Console.WriteLine();
            }
            string[] wartosc_miejsca_pion = new string[ilosc_pasazerow];
            string[] wartosc_miejsca_poziom = new string[ilosc_pasazerow];
            string[] wartosc_miejsca = new string[ilosc_pasazerow * 2] {};
           // string text = "Wybierz miejsce dla pasazerow";

            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                int j = i + 1;
                Console.WriteLine("Wybierz miejsce dla " + j + " pasazera");
                wartosc_miejsca = Console.ReadLine().Split(' ');
            }

            for(int i = 0; i < wartosc_miejsca.Length; i += 2)
            {
                wartosc_miejsca_pion[i] = wartosc_miejsca[i];
                wartosc_miejsca_poziom[i] = wartosc_miejsca[i + 1];
            }

            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                for (int j = 0; j < wartosc_miejsca_pion.Length; j++)
                {

                }
            }







        }
    }
}
