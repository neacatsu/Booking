using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Rezerwacja
    {

        public static string R_miejsce_wylotu(string miejsce_wylotu)
        {
           
            if (int.TryParse(miejsce_wylotu, out _) == true)
            {
                int miejsce_wyl = int.Parse(miejsce_wylotu);
                switch (miejsce_wyl)
                {
                    case 1:
                        return "Kraków";

                    case 2:
                        return "Katowice";

                    case 3:
                        return "Warszawa";
                    default:
                        return "Kraków";

                }
            }
            else return miejsce_wylotu;

        }


        public static string R_cel_podrozy(string cel_podrozy)
        {
           
            if (int.TryParse(cel_podrozy, out _) == true)
            {
                int cel_pod = int.Parse(cel_podrozy);
                switch (cel_pod)
                {
                    case 1:
                        return "Grecja";
                    case 2:
                        return "Bali";
                    case 3:
                        return "Lacjum";
                    case 4:
                        return "Berlin";
                    case 5:
                        return "Stambuł";
                    case 6:
                        return "Oslo";
                    case 7:
                        return "Kenya";
                    case 8:
                        return "Praga";
                    case 9:
                        return "Toronto";
                    case 10:
                        return "Moskwa";
                    default:
                        return "Grecja";

                }
            }
            else return cel_podrozy;
        }


        public static string R_klasa(string klasa)
        {
            if (int.TryParse(klasa, out _) == true)
            {
                int kl = int.Parse(klasa);
                switch (kl)
                {
                    case 1:
                        return "Biznesowa";
                    case 2:
                        return "Ekonomiczna";
                    case 3:
                        return "AllInclusive";
                    default:
                        return "Biznesowa";
                }
            }
            else return klasa;
        }




        public static double Rezerwacja_(string cel_podrozy, DateTime data_podrozy)
        {
            Console.Clear();

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
            
            for (int xi = 0; xi < 10; xi++)
            {
                if (cel_podrozy == tablica_miejsc[xi])
                {
                    if (wielkosc_czas > 30)
                    {
                        double znizka = tablica_cen[xi]*0.95;
                        return znizka;
                    }

                    return tablica_cen[xi];
                }
            }
            return 5;
        }
    }
}
