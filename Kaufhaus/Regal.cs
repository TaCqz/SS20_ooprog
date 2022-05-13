using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Regal
    {
        #region fields
        // Objektvariablen
        private readonly int _regalNummer;
        private List<Artikel> _artikelListe;
        #endregion
        #region properties
        public int RegalNummer { get => _regalNummer; }
        #endregion
        #region ctor
        public Regal(int regalNummer)
        {
            _regalNummer = regalNummer;
            _artikelListe = new List<Artikel>();

            Lager.AddRegal(this);
        }
        #endregion
        #region methods
        // Hinzufügen von Artikeln
        public void AddArtikel(Artikel artikel)
        {
            _artikelListe.Add(artikel);
        }
        // Entfernen von Artikeln
        public void RemoveArtikel(Artikel artikel)
        {
            _artikelListe.Remove(artikel);
        }
        // AsString-Methode, für Debug-Zwecke
        public string AsString() 
        {
            string s = "";
            foreach(Artikel artikel in _artikelListe)
            {
                s += artikel.Name + " " + artikel.Bestand + "\n";
            }
            return s;
        }
        #endregion
    }
}
