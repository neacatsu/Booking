using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Formularz
    {
        public enum Klasa
        {
            Biznesowa,
            Ekonomiczna,
            AllInclusive
        }
        public enum Miejsca
        {
            Kraków,
            Katowice,
            Warszawa
        }
        public enum Cel
        {
            Grecja,
            Bali,
            Lacjum,
            Berlin,
            Stambuł,
            Oslo,
            Kenya,
            Praga,
            Toronto,
            Moskwa
        }


        public static void Form()
        {
            var miejsce_enum= Enum.GetNames(typeof(Miejsca)).Length;
            for (int i = 0; i < miejsce_enum; i++)
            {
                Console.WriteLine(i+1+" "+(Miejsca)i);
            }
            Console.WriteLine("Podaj miejsce wylotu");
            var miejsce_wylotu = Console.ReadLine();



            var cel_enum = Enum.GetNames(typeof(Cel)).Length;
            for (int i = 0; i < cel_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Cel)i);
            }
            Console.WriteLine("Podaj cel podróży");
            var cel_podrozy = Console.ReadLine();

           
            Console.WriteLine("Podaj date podróży");
            DateTime data_podrozy= DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Podaj ilosc pasażerów");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());


            var klasa_enum = Enum.GetNames(typeof(Klasa)).Length;
            for (int i = 0; i < klasa_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (Klasa)i);
            }
            Console.WriteLine("Wybierz klase:");
            var klasa = Console.ReadLine();

            Wybor_miejsc.Wybor_miejsc_(ilosc_pasazerow);
            Console.WriteLine(Rezerwacja.Rezerwacja_( miejsce_wylotu,  cel_podrozy,  data_podrozy,  ilosc_pasazerow,  klasa));


        }

        
    }
}
