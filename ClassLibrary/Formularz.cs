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
        public enum klasa
        {
            Biznesowa,
            Ekonomiczna,
            AllInclusive
        }
        public enum miejsca
        {
            Kraków,
            Katowice,
            Warszawa
        }
        public enum cel
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
            var miejsce_enum= Enum.GetNames(typeof(miejsca)).Length;
            for (int i = 0; i < miejsce_enum; i++)
            {
                Console.WriteLine(i+1+" "+(miejsca)i);
            }
            Console.WriteLine("Podaj miejsce wylotu");
            var miejsce_wylotu = Console.ReadLine();



            var cel_enum = Enum.GetNames(typeof(cel)).Length;
            for (int i = 0; i < cel_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (cel)i);
            }
            Console.WriteLine("Podaj cel podróży");
            var cel_podrozy = Console.ReadLine();

           
            Console.WriteLine("Podaj date podróży");
            string[] data_wylotu = Console.ReadLine().Split(':');

            Console.WriteLine("Podaj ilosc pasażerów");
            int ilosc_pasazerow = int.Parse(Console.ReadLine());


            var klasa_enum = Enum.GetNames(typeof(klasa)).Length;
            for (int i = 0; i < klasa_enum; i++)
            {
                Console.WriteLine(i + 1 + " " + (klasa)i);
            }
            Console.WriteLine("Wybierz klase:");
            var klasa = Console.ReadLine();
            
            Wybor_miejsca(ilosc_pasazerow);
            //Rezerwacja.Rezerwacja_( miejsce_wylotu,  cel_podrozy,  data_wylotu,  ilosc_pasazerow,  klasa);



            


        }

        public static void Wybor_miejsca(int ilosc_pasazerow)


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
            for(int i=0;i< ilosc_pasazerow; i++)
            {
                int j = i + 1;
                Console.WriteLine("Wybierz miejsce dla "+ j +" pasazera");
                string[] wartosc_miejsca = Console.ReadLine().Split(' ');
            }
            
            

        }
    }
}
