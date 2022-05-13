using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Simulation
    {

        #region fields
        // Alle benötigten Felder für die Simulation
        private DateTime _datum = new DateTime();
        private DateTime _vortag = new DateTime();
        private string? _anfangsBestand; // Um den Anfangsbestand zu merken
        private string? _endBestand; // Um den Endbestand zu merken
        private List<int> _artikelBestandAnfang = new List<int>(); // Alle Artikel die zum Tagesstart vorhanden sind in Mengen
        private static int count = 0;
        private static double gesamtGewinn = 0;
        #endregion
        #region ctor
        // Konstruktor
        public Simulation(DateTime startDatum) 
        {
            _datum = startDatum;
        }
        #endregion
        #region properties
        public DateTime Datum { get => _datum; }
        public List<int> ArtikelBestandAnfang { get => _artikelBestandAnfang; }
        #endregion
        #region methods
        // Der Tagesstart ruf die AddToLog-Methode auf und gibt eine standartisierte Ausgabe auf der Konsole
        public void TagesStart()
        {
            Verwaltung.AddToLog($"------------------------------------------------------------------------\n" +
                                $"-    {Kaufhaus.Name,-7} | {Kaufhaus.Adresse,20}  -\n" +
                                $"------------------------------------------------------------------------\n" +
                                $"Datum: {_datum.ToShortDateString()}\n" +
                                $"Uhrzeit: { _datum.ToShortTimeString()}\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Verwaltung.AddToLog($"Laden hat nun geöffnet!\n\n");
            Console.ResetColor();

            // Um den Anfangsbestand zu merken
            _artikelBestandAnfang.Clear();

            foreach (Abteilung abteilung in Kaufhaus.Abteilung)
            {
                foreach (Artikel artikel in abteilung.Artikel)
                {
                    if (artikel.Bestand < artikel.Mindestbestand) Lager.Reorder(artikel);
                    
                    _anfangsBestand += $"Artikelname: {artikel.Name}   Menge: {artikel.Bestand}\n";
                    _artikelBestandAnfang.Add(artikel.Bestand);
                }
            }
            Verwaltung.AddToLog("\n\n");
            BetrittKundeLaden();
        }
        // Tagesende funktioniert ähnlich wie Tagesstart
        public void TagesEnde()
        {
            
            int c = 0;
            foreach (Abteilung abteilung in Kaufhaus.Abteilung)
            {
                foreach (Artikel artikel in abteilung.Artikel)
                {
                        // Errechnet die übrigen Mengen + den Gewinn anhand der marge der Einzelnen Artikel!
                        int verkauft =  _artikelBestandAnfang[c] - artikel.Bestand; // ÜBERARBEITEN!! DER BESTAND STIMMT NICHT!! -> Done
                        _endBestand += $"Artikelname: {artikel.Name,-34}   Menge: {artikel.Bestand,-2}         Verkauft: {verkauft}        Gewinn: {(artikel.Gewinn * verkauft):F2}\n"; // Bitte beachten: Gewinn != Einnahme! Der Gewinn ist bereits abzüglich des Einkaufspreises!
                        c++;
                        gesamtGewinn += artikel.Gewinn * verkauft;
                    verkauft = 0;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Verwaltung.AddToLog($"\n\nDer Laden hat nun geschlossen!\n\n");
            Console.ResetColor();
            // Fügt die grade getätigten Rechnungen sowie die beim Tagesstart ausgeführten Startmengen dem LOG hinzu
            Verwaltung.AddToLog(_endBestand);
            _endBestand = string.Empty;
            _anfangsBestand = string.Empty;
            Verwaltung.PrintLog(this);
            NaechsterTag();
        }
        public void SimulationStarten()
        {
            // Uhrzeit zur Öffnung
            while(this._datum.Hour < 8)
            {
                _datum =_datum.AddHours(+1.00);
            }
            while (_datum.Hour > 8)
            {
                _datum = _datum.AddHours(-1);
            }
            if (Directory.Exists("Log"))
            {
                Directory.Delete("Log", true);
            }
            Directory.CreateDirectory("Log");
            
            TagesStart();
        }
        // Hier wird geprüft ob ein Kunde den laden betritt
        public void BetrittKundeLaden()
        {
            var ran = new Random();
            int x = ran.Next(0, 100);
            if (x < 75) // 75% Wahrscheinlichkeit
            {
                x = 0;
                x = ran.Next(0, 100);
                if (x < 20) // 20% Wahrscheinlichkeit das es ein Kunde ist welcher gestern etwas gekauft hat
                {
                    List<Kunde> kundenGestern = new List<Kunde>();
                    foreach (Einkauf ein in Verwaltung.Einkauf)
                    {
                        if (ein.Datum == (_vortag = _datum.AddDays(-1)))
                        {
                            kundenGestern.Add(ein.Kunde);
                        }
                    }
                    x = 0;
                    if (kundenGestern.Count != 0) // Wenn es gestern keinen Kunden gab, einfach überpringen
                    {
                        x = ran.Next(0, kundenGestern.Count);
                        KundeKauftEin(kundenGestern[x]);
                    }
                    NaechsteStunde();

                }
                else
                {
                    Kunde k = DynamicCustomer.Dynamic();
                    KundeKauftEin(k);
                }

            }
            else NaechsteStunde();
        }
        // Wenn ein Kunde den Laden betritt, wird hier entschieden was gekauft wird!
        public void KundeKauftEin(Kunde k)
        {
            var ran = new Random();
            int x = 0;
            int y = 0;
            // Kaufen des Ersten Artikels
            int abteilungenAnzahl = Kaufhaus.Abteilung.Count;
            x = ran.Next(0, abteilungenAnzahl);

            int artikelAnzahl = Kaufhaus.Abteilung[x].Artikel.Count;
            y = ran.Next(0, artikelAnzahl);
            Einkauf kauf = new Einkauf(Kaufhaus.Abteilung[x].Artikel[y], k, _datum, ran.Next(1, 4));

            // Zweiter Artikel
            x = ran.Next(0, abteilungenAnzahl);

            artikelAnzahl = Kaufhaus.Abteilung[x].Artikel.Count;
            y = ran.Next(0, artikelAnzahl);
            Einkauf kauf2 = new Einkauf(Kaufhaus.Abteilung[x].Artikel[y], k, _datum, ran.Next(1, 4));

            // Dritter Artikel mit Prüfung ob selbe Abteilung
            x = ran.Next(0, abteilungenAnzahl);

            // Wenn der erste Kauf + der Zweite Kauf aus der selben Abteilung sind wie der Dritte kauf...
            if (kauf.Artikel != null && kauf2.Artikel != null)
            {
                while (kauf.Artikel.Abteilung == kauf2.Artikel.Abteilung && Kaufhaus.Abteilung[x] == kauf.Artikel.Abteilung)
                {
                    x = ran.Next(0, abteilungenAnzahl); // Wird der Zufall wiederholt!
                }
            }
            artikelAnzahl = Kaufhaus.Abteilung[x].Artikel.Count;
            y = ran.Next(0, artikelAnzahl);
            Einkauf kauf3 = new Einkauf(Kaufhaus.Abteilung[x].Artikel[y], k, _datum, ran.Next(1, 4));

            NaechsteStunde();
        }
        public void NaechsteStunde()
        {
            if(_datum.Hour < 20)
            {
              _datum =_datum.AddHours(1); // Nächste Stunde wird gestartet, da DateTime.AddHours() nicht das Datetime-Objekt ändert, sondern ein neues zurrückgibt,
                                          // Wird _datum überschrieben mit dem neuen Datum (+1 Stunde)
                BetrittKundeLaden();
            }
            else if(_datum.Hour == 20)
            {
                TagesEnde();
            }
            
        }
        public void NaechsterTag() // Für SL4
        {
            if(count == 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (count == 4)
                {
                    Verwaltung.AddToLog($"\nDer gesamte Gewinn dieser Woche beträgt:     {gesamtGewinn:F2}\n\n");
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Simulation beendet! Beliebige Taste drücken um Programm zu beenden!");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);

            } else if (count < 4)
            {
                _datum = _datum.AddHours(-12);
                _datum = _datum.AddDays(1);
                count++;
                this.TagesStart();
                
            }
            
        }
        #endregion
    }
}
