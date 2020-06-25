using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Rezerwacja
    {
        public static void Rezerwacja_(string miejsce_wylotu, string cel_podrozy, DateTime data_podrozy, int ilosc_pasazerow, string klasa)
        {
            Console.Clear();

            int num1;
            if (int.TryParse(miejsce_wylotu, out num1) == true)
            {
                int miejsce_wyl = int.Parse(miejsce_wylotu);
                switch (miejsce_wyl)
                {
                    case 1:
                        Console.WriteLine("Kraków");
                        break;
                    case 2:
                        Console.WriteLine("Katowice");
                        break;
                    case 3:
                        Console.WriteLine("Warszawa");
                        break;
                }
            }
            else Console.WriteLine(miejsce_wylotu);

            int num2;
            if (int.TryParse(cel_podrozy, out num2) == true)
            {
                int cel_pod = int.Parse(cel_podrozy);
                switch (cel_pod)
                {
                    case 1:
                        Console.WriteLine("Grecja");
                        break;
                    case 2:
                        Console.WriteLine("Bali");
                        break;
                    case 3:
                        Console.WriteLine("Lacjum");
                        break;
                    case 4:
                        Console.WriteLine("Berlin");
                        break;
                    case 5:
                        Console.WriteLine("Stambuł");
                        break;
                    case 6:
                        Console.WriteLine("Oslo");
                        break;
                    case 7:
                        Console.WriteLine("Kenya");
                        break;
                    case 8:
                        Console.WriteLine("Praga");
                        break;
                    case 9:
                        Console.WriteLine("Toronto");
                        break;
                    case 10:
                        Console.WriteLine("Moskwa");
                        break;

                }
            }
            else Console.WriteLine(cel_podrozy);

            int num3;
            if (int.TryParse(klasa, out num3) == true)
            {
                int kl = int.Parse(miejsce_wylotu);
                switch (kl)
                {
                    case 1:
                        Console.WriteLine("Biznesowa");
                        break;
                    case 2:
                        Console.WriteLine("Ekonomiczna");
                        break;
                    case 3:
                        Console.WriteLine("AllInclusive");
                        break;
                }
            }
            else Console.WriteLine(miejsce_wylotu);


            List<Miejsca_podrozy.Miejsca> lista_cen = Miejsca_podrozy.Lista_miejsc();

            string[] tablica_miejsc = new string[10];
            int[] tablica_cen = new int[10];
            int i = 0;
            foreach (Miejsca_podrozy.Miejsca lista_cennik in lista_cen)
            {
                tablica_miejsc[i] = lista_cennik.Nazwa;
                tablica_cen[i] = int.Parse(lista_cennik.Cena);
                i++;
            }

            DateTime thisDay = DateTime.Now;
            TimeSpan czas = data_podrozy - thisDay;
            int wielkosc_czas = czas.Days;
            int w = 0;
            double znizka = 0;
            for (int xi = 0; xi < 10; xi++)
            {
                if (wielkosc_czas > 30)
                {
                    if (cel_podrozy == tablica_miejsc[xi])
                    {
                        w = xi;
                        znizka = tablica_cen[xi]*0.95;
                    }
                }

            }








        }







    }
}
