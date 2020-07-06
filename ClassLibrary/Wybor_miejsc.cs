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



        public static string[,] Odczyt_miejsc()
        {
            // ODCZYT PLIKU DO TABLICY
            string[,] tablica_miejsc = new string[16, 6];
            String wejscie = File.ReadAllText("wyb_m.txt");
            int a = 0;
            foreach (var rzad in wejscie.Split('\n'))
            {
                int b = 0;
                foreach (var kolumna in rzad.Trim().Split(' '))
                {
                    tablica_miejsc[a, b] = kolumna.Trim();
                    b++;
                }
                a++;
            }
            return tablica_miejsc;
        }

        public static bool Czy_pelny(string[,] tab)
        {
            for (int i = 1; i < tab.GetLength(0); i++)
            {
                for (int j = 1; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == "0") return true;
                }
            }
            return false;
        }



        public static string[] Wartosc_miejsc(string[] tab, string wartosc, int ilosc)
        {
            // SPISYWANIE WARTOSCI MIEJSC WPISANYCH PRZEZ UZYTKOWNIKA DO TABLICY
            int i = ilosc * 2 - 2;
            char[] temp_tab = wartosc.ToCharArray();
            string wartosc1 = temp_tab[0].ToString();
            string wartosc2 = temp_tab[1].ToString();
            if (temp_tab.Length == 3)
            {
                wartosc2 = String.Concat(temp_tab[1], temp_tab[2]);
            }
            tab[i] = wartosc1;
            tab[i + 1] = wartosc2;
            return tab;
        }

        public static string[,] Zamiana_wartosci(string[,] tablica_miejsc, string[] wartosc_miejsca, int ilosc_pasazerow)
        {
            int[] index_poziom = new int[ilosc_pasazerow];
            int[] index_pion = new int[ilosc_pasazerow];
            string[] poziom = new string[ilosc_pasazerow];
            int k = 0;

            // POBIERANIE WARTOSCI INDEXOW
            for (int i = 0; i < wartosc_miejsca.Length; i += 2)
            {
                for (int j = 1; j < tablica_miejsc.GetLength(1); j++)
                    if (wartosc_miejsca[i].ToString() == tablica_miejsc[0, j]) poziom[k] = tablica_miejsc[0, j];
                k++;
            }

            k = 0;
            for (int i = 0; i < wartosc_miejsca.Length; i += 2)
            {
                for (int j = 1; j < tablica_miejsc.GetLength(0); j++)
                    if (wartosc_miejsca[i + 1].ToString() == tablica_miejsc[j, 0]) index_pion[k] = int.Parse(tablica_miejsc[j, 0]);
                k++;

            }

            // KONWERSJA LITER NA ODPOWIADAJACE LICZBY
            for (int i = 0; i < poziom.Length; i++)
            {
                if (poziom[i] == "A") index_poziom[i] = 1;
                else if (poziom[i] == "B") index_poziom[i] = 2;
                else if (poziom[i] == "C") index_poziom[i] = 4;
                else if (poziom[i] == "D") index_poziom[i] = 5;
            }

            // ZAMIANA WARTOSCI 0 NA X
            for (int i = 0; i < ilosc_pasazerow; i++)
            {
                if (tablica_miejsc[index_pion[i], index_poziom[i]] == "0") tablica_miejsc[index_pion[i], index_poziom[i]] = "X";
            }

            if (Czy_pelny(tablica_miejsc) == false)
            {
                // ODCZYT CZYSTEGO PLIKU DO TABLICY
                string[,] nowe_miejsca = new string[16, 6];
                String wejscie = File.ReadAllText("miejsca_zapas.txt");
                int a = 0;
                foreach (var rzad in wejscie.Split('\n'))
                {
                    int b = 0;
                    foreach (var kolumna in rzad.Trim().Split(' '))
                    {
                        nowe_miejsca[a, b] = kolumna.Trim();
                        b++;
                    }
                    a++;
                }
                return nowe_miejsca;
            }

            return tablica_miejsc;
        }

        public static void Zapis_miejsc(string[,] tablica_miejsc)
        {
            // CZYSZCZENIE OBECNEGO PLIKU
            System.IO.File.WriteAllText(@"wyb_m.txt", string.Empty);

            // ZAPIS WLASCIWY
            using (var writer = File.AppendText("wyb_m.txt"))
            {
                for (int i = 0; i < tablica_miejsc.GetLength(0); i++)
                {
                    for (int j = 0; j < tablica_miejsc.GetLength(1); j++)
                    {
                        if (j + 1 == tablica_miejsc.GetLength(1)) writer.Write(tablica_miejsc[i, j]);
                        else writer.Write(tablica_miejsc[i, j] + " ");
                    }
                    if (i + 1 < tablica_miejsc.GetLength(0)) writer.WriteLine();
                }
            }
        }
    }
}
