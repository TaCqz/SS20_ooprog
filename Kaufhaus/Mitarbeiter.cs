using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Mitarbeiter
    {
        #region fields
        // Objektvariablen
        private readonly string _name;
        private readonly DateTime _gebDatum;
        private Abteilung? _abteilung;
        private double _gehalt;
        private Abteilungsleiter? _vorgesetzter;

        #endregion
        #region properties
        // Getter/Setter für benötigte Felder
        public Abteilung? Abteilung { 
            set => _abteilung = value; get => _abteilung;
        }
        public Abteilungsleiter? Vorgesetzter {
            get => _vorgesetzter; 
            set => _vorgesetzter = value;}
        public string Name { get => _name; }
        public DateTime GebDatum { get => _gebDatum; }
        public double Gehalt { get => _gehalt; }
        #endregion
        #region ctor
        // Konstruktor mit Name, Geburtsdatum und Gehalt. Abteilungsleiter wird später gesetzt und hängt von der Abteilung ab!
        public Mitarbeiter(string name, DateTime gebDatum, double gehalt)
        {
            _name = name;
            _gebDatum = gebDatum;
            _gehalt = gehalt;

            Verwaltung.AddMitarbeiter(this);
        }
        #endregion
        #region methods
        public void AsString() 
        {
            Console.WriteLine($"{_name, -5} {_gebDatum,5} {_abteilung,5} {_gehalt,5} {_vorgesetzter,5}");
        }
        // Hinzufügen zur Abteilung und festlegen des Abteilungsleiters
        public void AddToAbteilung(Abteilung abteilung)
        {
            this.Abteilung = abteilung;
            this.Vorgesetzter = abteilung.Leiter;
        }
        #endregion
    }
}
