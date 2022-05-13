using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    class Kaufhaus
    {
        #region fields
        private static readonly string _adresse = "Hauptstr. 1, 29389 Bad Bodenteich";
        private static readonly string _name = "Edeko Centre Kaufhaus am See";
        private static List<Abteilung> _abteilungen = new List<Abteilung>();

        #endregion

        #region properties
        public static string Adresse { get => _adresse; }
        public static string Name { get => _name; }
        public static List<Abteilung> Abteilung { get => _abteilungen; }
        #endregion

        #region methods
        public static void AddAbteilung(Abteilung abteilung)
        {
            _abteilungen.Add(abteilung);
        }
        #endregion
    }
}
