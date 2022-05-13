using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Verwaltung
    {
        #region fields
        // Verbindungen zu allen zu Verwaltende Klassen
        private static List<Kunde> _kunden = new List<Kunde>();
        private static List<Einkauf> _einkaeufe = new List<Einkauf>();
        private static List<int> _artikelNummern = new List<int>();
        //private static List<Abteilung> _abteilungen = new List<Abteilung>();
        private static List<Mitarbeiter> _mitarbeiter = new List<Mitarbeiter>();
        private static List<Abteilungsleiter> _abteilungsleiter = new List<Abteilungsleiter>();
        private static string log = "";
        #endregion

        #region properties
        public static List<Kunde> Kunden { get => _kunden; }
        //public static List<Abteilung> Abteilung { get => _abteilungen; }
        public static List<Einkauf> Einkauf { get => _einkaeufe; }
        #endregion
        #region methods
        // Methoden zum hinzufügen von Kunden, Einkäufen, Abteilungen, Abteilungsleitern und Mitarbeitern zur Verwaltung
        public static void AddKunde(Kunde kunde)
        {
            _kunden.Add(kunde);
        }
        public static void AddEinkauf(Einkauf einkauf)
        {
            _einkaeufe.Add(einkauf);
        }
        //public static void AddAbteilung(Abteilung abteilung)
        //{
        //    _abteilungen.Add(abteilung);
        //}
        public static void AddAbteilungsleiter(Abteilungsleiter ab)
        {
            _abteilungsleiter.Add(ab);
        }
        public static void AddMitarbeiter(Mitarbeiter mitarbeiter)
        {
            _mitarbeiter.Add(mitarbeiter);
        }
        // PrintOverview zur Ausgabe sämtlicher Kaufhausbezogenen Daten
        public static void PrintOverview()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"-    {Kaufhaus.Name,-7} | {Kaufhaus.Adresse,20}  -");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Abteilungen:\n\n");
            // Informationen zu allen Abteilungen
            foreach (Abteilung abteilung in Kaufhaus.Abteilung)
            {
                Console.Write($"{abteilung.Name,-20} {abteilung.Flaecheqm,5}m²   Abteilungsleiter: {abteilung.Leiter.Name,-15} {abteilung.Leiter.Buero}\n");
            }
            Console.Write("------------------------------------------------------------------------\n");
            // Informationen zu allen Mitarbeitern
            Console.WriteLine("Mitarbeiter:\n\n");
            foreach (Mitarbeiter ma in _mitarbeiter)
            {
                Console.WriteLine($"{ma.Name,-25} {ma.Abteilung.Name,-20} {ma.GebDatum.ToShortDateString(),-13} {ma.Gehalt,-8} {ma.Vorgesetzter.Name,-20}");
            }
            Console.WriteLine();
            foreach (Abteilungsleiter ab in _abteilungsleiter)
            {
                Console.WriteLine($"{ab.Name,-25} {ab.Abteilung.Name,-20} {ab.GebDatum.ToShortDateString(),-13} {ab.Gehalt,-8} {ab.Buero,-20}");
            }
            Console.WriteLine("------------------------------------------------------------------------");
            // Informationen zu allen Artikeln
            foreach (Abteilung abteilung in Kaufhaus.Abteilung)
            {

                Console.WriteLine($"Artikel in {abteilung.Name}:\n");
                foreach (Artikel art in abteilung.Artikel)
                {
                    Console.WriteLine($"{art.Name,-35} {art.Preis,-6} Bestand: {art.Bestand,3}       Lageregal: {art.Regal.RegalNummer}");
                }
                Console.WriteLine();
            }

        }
        // Hinzufügen vom string s zum Log, wird zu verschiedenen Gelegenheiten aufgerufen
        public static void AddToLog(string? s)
        {
            Console.WriteLine(s);
            log += $"\n{s}";

        }
        // Wenn Einkäufe getätigt werden, werden sie dem Log hinzugefügt
        public static void AddToLog(Einkauf einkauf)
        {
            if (einkauf.Menge > 0)
            {
                Console.WriteLine("Einkauf:     ");
                log += "\n" + "Einkauf:     ";
                Console.Write(einkauf.Kunde.Name + ", ");
                log += "\n" + einkauf.Kunde.Name + ", ";
                Console.Write(einkauf.Artikel.Name + ", ");
                log += "\n" + einkauf.Artikel.Name + ", ";
                Console.Write(einkauf.Menge + ", ");
                log += "\n" + einkauf.Menge + ", ";
                Console.Write(einkauf.Datum.ToShortDateString() + "  " + einkauf.Datum.ToShortTimeString() + "\n\n");
                log += "\n" + einkauf.Datum.ToShortDateString() + "  " + einkauf.Datum.ToShortTimeString() + "\n\n";
            } else if (einkauf.Menge == 0)
            {
                Console.WriteLine($"Der Kunde {einkauf.Kunde.Name} wollte den Artikel {einkauf.Artikel} kaufen, dieser ist aber leider Ausverkauft! \n");
                log += $"Der Kunde/Die Kundin {einkauf.Kunde.Name} wollte den Artikel {einkauf.Artikel.Name} kaufen, dieser ist aber leider Ausverkauft! \n";
            }
        }
        // Ausgabe des Logs, gegebenenfalls löschen der Datei falls vorhanden
        public static void PrintLog(Simulation sim)
        {
            string logname = $"Log-{sim.Datum.ToShortDateString()}";
            if (File.Exists($"Log/{logname}.txt"))
            {
                File.Delete($"Log/{logname}.txt");
            }
            System.IO.File.WriteAllText($"Log/{logname}.txt", log);
            // Leersetzen des Strings für den nächsten Tag
            log = "";
            logname = string.Empty;
        }
        // Überprüfen ob Artikelnummer bereits vorhanden ist
        public static bool PrüfeNummer(int x)
        {
            if (_artikelNummern.Contains(x)) return true;
            else return false;
        }
        // Hinzufügen von Artikelnummern zum Überprüfen späterer Artikel
        public static void AddNummer(int x)
        {
            _artikelNummern.Add(x);
        }
        #endregion
    }
}
