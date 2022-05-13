using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Einkauf
    {
        #region fields
        // Objektvariablen
        private Artikel _artikel;
        private Kunde _kunde;
        private DateTime _datum;
        private int _menge;
        #endregion
        #region properties
        // Getter/Setter
        public Artikel Artikel { get => _artikel; }
        public Kunde Kunde { get => _kunde; }
        public DateTime Datum { get => _datum; }
        public int Menge { get => _menge; }
        #endregion
        #region ctor
        // Jeder Einkauf wird registriert mit dem Artikel, Kunden, Datum und der Menge des Artikels. Die Menge wird mit dem Bestand verglichen, anschließend wird der Bestand geändert.
        // Anschließend wird das ganze dem Log hinzugefügt.
        public Einkauf(Artikel artikel, Kunde kunde, DateTime datum, int menge)
        {
            if (artikel.Bestand < menge)
            {
                if (artikel.Bestand == 0) return;
                else menge = artikel.Bestand;
            }
            _artikel = artikel;
            _kunde = kunde;
            _datum = datum;
            _menge = artikel.MengePrüfen(menge);
            artikel.BestandAendern(artikel, _menge);


            Verwaltung.AddEinkauf(this);
            Verwaltung.AddToLog(this);
        }
        #endregion
    }
}
