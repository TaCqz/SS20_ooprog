using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Kunde
    {
        #region fields
        // Objektvariablen
        private readonly string _name;
        private readonly string _adresse;
        private readonly string _gebDate;
        private readonly int _id;
        // Statische Variablen
        private static int lfdNr = 0;
        
        private List<Einkauf> _einkaeufe;
        #endregion
        #region properties
        public string Name { get => _name; }
        public List<Einkauf> Einkaeufe { get => _einkaeufe; }
        #endregion
        #region ctor
        // Kunden haben einen Namen, eine Adresse und ein Geburtsdatum
        public Kunde(string name, string adresse, string gebDate)
        {
            _name = name;
            _adresse = adresse;
            _gebDate = gebDate;
            // Jeder Kunde bekommt eine eindeutige ID
            _id += lfdNr;
            // Zu jedem Kunden wird ein Einkäufe-Listenobjekt erstellt
            _einkaeufe = new List<Einkauf>();
            // Hinzufügen zur Verwaltung
            Verwaltung.AddKunde(this);
        }
        #endregion
        #region methods
        #endregion
    }
}
