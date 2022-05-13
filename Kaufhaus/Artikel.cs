using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/


namespace Kaufhaus
{
    public class Artikel
    {
        #region fields
        private readonly string _name;
        private double _epreis;
        private double _marge;
        private double _verkaufspreis;
        private int _bestand;
        private int _mindestbestand;
        private int _anfangsBestand;

        private readonly int _artikelnummer; // Eindeutig, fünfstellig, wird mittels der Methode "RandomNumber()" erstellt
        private List<int> _artikelnummern = new List<int>(); // Eine Liste aller Artikelnummern
        private readonly Abteilung _abteilung;
        private Regal _regal;
        #endregion
        #region properties
        // Benötigte Getter und Setter
        public int anfangsBestand { get => _anfangsBestand; set => _anfangsBestand = value; }
        public string Name { get => _name; }
        public int Mindestbestand { get => _mindestbestand; set => _mindestbestand = value; }
        public int Bestand { get => _bestand; }
        public double Preis { get => _verkaufspreis; }
        public double Gewinn { get => _marge; }
        public Regal Regal { get => _regal; }
        public Abteilung Abteilung { get => _abteilung; }
        #endregion
        #region ctor
        // Konstruktor des Artikels, ein leerer Konstruktor wird nicht implementiert, da er nie benötigt wird!
        public Artikel(string name, double epreis, double verkaufspreis, Abteilung abteilung, Regal regal)
        {
            // Setzten der Objektvariablen mittels der übergebenen Werte des Konstruktors
            _name = name;
            _epreis = epreis;
            _marge = verkaufspreis - epreis;
            _verkaufspreis = verkaufspreis;
            _bestand = AnfangsBestand();
            _mindestbestand = _bestand / 2;
            _abteilung = abteilung;
            _regal = regal;

            regal.AddArtikel(this);
            abteilung.AddArtikel(this);
            _artikelnummer = RandomNummer(this);
            
          
        }
        #endregion

        #region methods
        public static int RandomNummer(Artikel artikel)
        {
            Random rand = new Random();
            int x = rand.Next(10000, 99999); //Da die Zahl fünfstellig sein soll, liegt sie zwischen 10000 und 99999
            while (Verwaltung.PrüfeNummer(x) == true) // Überprüfen ob diese Artikelnummer bereits existiert
            {
                x = 0; // Wenn sie bereits existiert, setze x = 0 und versuche die nächste Zahl
                x = rand.Next(10000, 99999);
            }
            Verwaltung.AddNummer(x); // Rufe die Methode AddNummer() in der Kaufhausklasse auf
            return x; // Übergebe x an den ctor
            
            
        }
        // Zufälliges setzten des Anfangsbestandes - Maximal 20, ein guter Mittelwert für alle Abteilungen.
        public int AnfangsBestand()
        {
            var rand = new Random();
            return rand.Next(4, 20);
        }
        public void BestandAendern(Artikel artikel, int aenderung) // Änderung des Bestands mittels des Artikelobjekts und dem Wert der Änderung - 
                                                                   //positiv für Bestellung/Rückgabe, negativ für Kauf/Retoure
        {
            _bestand -= aenderung; // Ändere den Bestand
            if(_bestand < _mindestbestand) // Wenn der Bestand unter dem Mindestbestand liegt...
            {
                Lager.BestandNiedrig(artikel); // Rufe Nachbestellen() auf
            }
        }
        public int MengePrüfen(int menge)
        {
            if (menge > _bestand)
            {
                if (_bestand == 0) return 0;
                else
                {
                    return _bestand;
                }
            }
            else if (menge == _bestand) return _bestand;
            else return menge;
        }
       
        #endregion
    }
}
