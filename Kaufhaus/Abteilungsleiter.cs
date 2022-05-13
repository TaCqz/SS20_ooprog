using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Abteilungsleiter
    {
        
        #region fields
        // Objektvariablen
        private readonly string _name;
        private readonly DateTime _gebDatum;
        private Abteilung? _abteilung;
        private double _gehalt;
        private string _buero;
        #endregion
        #region properties
        // Getter-/Setter
        public Abteilung? Abteilung
        {
            get => _abteilung;
            set => _abteilung = value;
        }
        public string Name { get => _name; }
        public string Buero { get => _buero; }
        public DateTime GebDatum { get => _gebDatum; }
        public double Gehalt { get => _gehalt; }
        #endregion
        #region ctor
        // Abteilungsleiter mit Namen, Geburtsdatum, Gehalt und Büro
        public Abteilungsleiter(string name, DateTime gebDatum, double gehalt, string buero)
        {
            _name = name;
            _gebDatum = gebDatum;
            _gehalt = gehalt;
            _buero = buero;

            Verwaltung.AddAbteilungsleiter(this);
        }
        #endregion

        #region methods
        public void AddToAbteilung(Abteilung abteilung)
        {
            this.Abteilung = abteilung;
        }
        #endregion
    }
}
