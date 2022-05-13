using System;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Test
    {
        public void Run()
        {

            Regal regal = new Regal(1);
            // Mitarbeiter, Abteilungsleiter, Artikel und Abteilung 1
            Mitarbeiter ma1 = new Mitarbeiter("Freddy Krueger", new DateTime(1997, 08, 05), 2320.84);
            Mitarbeiter ma2 = new Mitarbeiter("Michael Meyers", new DateTime(1997, 07, 05), 3320.84);
            Abteilungsleiter ab1 = new Abteilungsleiter("Samara Morgan", new DateTime(1980, 02, 04), 4980.77, "Klamottenbuero");
            Abteilung klamotten = new Abteilung("Klamotten", 243, ab1, ma1, ma2);
            Artikel hemd = new Artikel("Hemd", 20, 25, klamotten, regal);
            Artikel jeans = new Artikel("Jeans", 15, 22.99, klamotten, regal);

            // Mitarbeiter, Abteilungsleiter, Artikel und Abteilung 2
            Mitarbeiter ma3 = new Mitarbeiter("Tech Nick", new DateTime(1987, 12, 04), 2320.84);
            Mitarbeiter ma4 = new Mitarbeiter("William WasGehtSieDasAn", new DateTime(1989, 07, 24), 3320.84);
            Abteilungsleiter ab2 = new Abteilungsleiter("Max Marx", new DateTime(1969, 04, 18), 4980.77, "Elektronikbuero, Werkstatt");
            Abteilung elektroartikel = new Abteilung("Elektronikabteilung", 420, ab2, ma3, ma4);
            Artikel gamingPC = new Artikel("Gaming PC V1 Intel i7 8700k", 850, 939.99, elektroartikel, regal);
            Artikel fernseher = new Artikel("Fernseher WQHD Ultra von Samsong", 1000, 1099, elektroartikel, regal);

            // Mitarbeiter, Abteilungsleiter, Artikel und Abteilung 3
            Mitarbeiter ma5 = new Mitarbeiter("Moritz Pritzel", new DateTime(2000, 06, 20), 449.89);
            Mitarbeiter ma6 = new Mitarbeiter("Jan-Oliver Lehnen", new DateTime(1997, 08, 05), 880.79);
            Abteilungsleiter ab3 = new Abteilungsleiter("Markus Boss", new DateTime(1978, 04, 22), 4980.77, "Kassenbuero Lebensmittel");
            Abteilung lebensmittel = new Abteilung("Lebensmittel", 120, ab3, ma5, ma6);
            Artikel brot = new Artikel("Harrie Vollkornbrot", 1.49, 1.79, lebensmittel, regal);
            Artikel apfel = new Artikel("Apfel, 1KG Sack", 2.29, 2.69, lebensmittel, regal);

            // Mitarbeiter, Abteilungsleiter, Artikel und Abteilung 4
            Mitarbeiter ma7 = new Mitarbeiter("Marie Ikea", new DateTime(1996, 06, 29), 1449.89);
            Mitarbeiter ma8 = new Mitarbeiter("Heike Roller", new DateTime(1992, 11, 05), 1880.79);
            Abteilungsleiter ab4 = new Abteilungsleiter("Randy Randale", new DateTime(1978, 08, 22), 4980.77, "Möbellager, Buero");
            Abteilung möbel = new Abteilung("Möbelabteilung", 820, ab4, ma7, ma8);
            Artikel Tisch = new Artikel("Tisch, Eiche", 89, 99.99, möbel, regal);
            Artikel Stuhl = new Artikel("Stuhl, auch Eiche", 39, 54.99, möbel, regal);

            // Mitarbeiter, Abteilungsleiter, Artikel und Abteilung 5
            Mitarbeiter ma9 = new Mitarbeiter("Imke Diamant", new DateTime(1970, 02, 27), 1449.89);
            Mitarbeiter ma10 = new Mitarbeiter("Harald Hartmann", new DateTime(1990, 09, 05), 1880.79);
            Abteilungsleiter ab5 = new Abteilungsleiter("Bully Bullmann", new DateTime(1988, 08, 12), 4980.77, "Juwelierbüro");
            Abteilung schmuck = new Abteilung("Schmuckabteilung", 80, ab5, ma9, ma10);
            Artikel diadem = new Artikel("Diadem, Kristall", 89, 99.99, schmuck, regal);
            Artikel ohrring = new Artikel("Ohrring, Diamant", 339, 394.99, schmuck, regal);


            //Verwaltung.PrintOverview();
            Simulation sim = new Simulation(new DateTime(2020, 06, 01));
            sim.SimulationStarten();
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

            Test test = new Test();
            test.Run();
        }
    }
}
