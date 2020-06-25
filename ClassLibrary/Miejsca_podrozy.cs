using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Miejsca_podrozy
    {
        public class Miejsca
        {
            public string Nazwa { get; private set; }
            public string Cena { get; private set; }
            public string Zabytki { get; private set; }

            public Miejsca(string miejsce, string zwiedzanie, string koszt)
            {
                Nazwa = miejsce;
                Zabytki = zwiedzanie;
                Cena = koszt;

            }
        }

        public static List<Miejsca> Lista_miejsc()
        {
            Console.Clear();
            List<Miejsca> lista_miejsc = new List<Miejsca>();

            lista_miejsc.Add(new Miejsca("Grecja", "Wyjazd zgodnie z rozkładem jazdy, przejazd przez Słowację i Węgry do Serbii. Zwiedzanie stolicy byłej Jugosławii, Belgradu. Okazja, by zobaczyć słynną Twierdzę Kalemegdan," +
                " cerkiew św. Sawy, ulicę Skadarlija, deptak Knez Mihailova, ruiny budynków zbombardowanych przez siły NATO w 1999 roku.", "199"));
            lista_miejsc.Add(new Miejsca("Bali", "Wyspa tysiąca świątyń, wyspa zaczarowana, piękna i pozostająca w pamięci każdego, kto chociaż raz ją odwiedził. Zieleń bijąca z tarasów ryżowych, magiczne świątynie, kolory," +
                " egzotyczne krajobrazy, zawsze uśmiechnięci ludzie i ogarniający wszystko pokój - tak można opisać Bali.", "399"));
            lista_miejsc.Add(new Miejsca("Lacjum", "Lacjum sąsiaduje z Toskanią, Umbrą, Abrazją, Molise, Kampanią i Marche. Niekwestionowaną perłą regionu jest stolica Włoch, czyli Rzym. Będąc w nim koniecznie trzeba zobaczyć Koloseum, Forum Romanum czy Fontannę di Trevi.", "159"));
            lista_miejsc.Add(new Miejsca("Berlin", "Mur Berliński, Checkpoint Charlie, Brama Brandenburska czy Pałac Charlottenburg – to tylko ułamek atrakcji, które będziecie mieli okazję zobaczyć w Berlinie. Swój raj odnajdą tutaj także fani bursztynowego trunku.", "229"));
            lista_miejsc.Add(new Miejsca("Stambuł", "Intrygująca metropolia, miasto leżące na dwóch kontynentach. W programie niezapomniany rejs po Bosforze i znakomita zabawa na wieczorze tureckim w jaskiniach Kapadocji. ", "198"));
            lista_miejsc.Add(new Miejsca("Oslo", "Glówna arteria miasta, Karl Johans z dworca kolejowego biegnie pod góre obok katedry i dociera do budynku parlamentu - Stortinget. ", "198"));
            lista_miejsc.Add(new Miejsca("Kenya", "Przyjazny, kameralny hotel położony na północnym wybrzeżu Mombasy, w tropikalnym ogrodzie. Niedaleko Park Hallera, czyli ZOO zwierząt afrykańskich oraz centrum handlowe z restauracjami i dyskotekami. Do centrum Mombasy ok. 14km, ok. 20km do lotniska w Mombasie.", "339"));
            lista_miejsc.Add(new Miejsca("Praga", "Praga jest miejscem magicznym. Jej każdy zaułek oczarowuje. Dla mnie to przede wszystkim miasto mrocznych wież ( o tym później) pysznego, choć trochę ciężkiego jedzenia i absolutnie wspaniałych zdobień na budynkach. ", "256"));
            lista_miejsc.Add(new Miejsca("Toronto", "To największe miasto Kanady położone nad jeziorem Ontario w południowej części prowincji Ontario, której jest stolicą. To niezwykle turystyczne miasto wyróżnia się pod wieloma względami.", "358"));
            lista_miejsc.Add(new Miejsca("Moskwa", "Przyjechaliście do Rosji w celach biznesowych albo macie kilkugodzinną przesiadkę? Zapraszamy Was na spacer po głównych atrakcjach stolicy Moskwy zlokalizowanych wokół Placu Czerwonego. Jeśli oprócz „turystycznego moskiewskiego standardu” chcecie zobaczyć więcej miejsc do zwiedzania, to zapraszamy Was na wpis z nietypowymi atrakcjami Moskwy.", "217"));
            return lista_miejsc;
            

            
        }
        public static void Miejsca_p()
        {
            List<Miejsca> lista_miejsc = Lista_miejsc();

            foreach (Miejsca lista_miejsca in lista_miejsc)
            {
                Console.WriteLine(" \nMiejsce: " + lista_miejsca.Nazwa + " \nZabytki: " + lista_miejsca.Zabytki + "\nCena: " + lista_miejsca.Cena + "zł/za os");
                Console.WriteLine();
            }

        }





    }
}
