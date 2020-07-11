using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Promocja_lot
    {
        public static string Promocja()
        {
            
            Random rnd = new Random();
            int losowa_liczba = rnd.Next(0, 9);

            string[,] miejsca_promocja = new string[10, 2] {
                {"Grecja",  "99" }, {"Bali",  "199" }, {"Lacjum",  "120" }, {"Berlin",  "114" }, {"Stambuł",  "119" },
                {"Oslo",  "129" },{"Kenya",  "109" },{"Praga",  "129" },{"Toronto",  "119" },{"Moskwa",  "99" }
             };

            return $"{miejsca_promocja[losowa_liczba, 0]} {miejsca_promocja[losowa_liczba, 1]} zł\n";
            
            
            
        }


    }
}
