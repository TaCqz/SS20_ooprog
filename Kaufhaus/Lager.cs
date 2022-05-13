using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Lager
    {
        #region fields
        private static List<Regal>? _regale = new List<Regal>();
        #endregion
        #region properties
        public List<Regal> Regale = new List<Regal>();
        #endregion
        #region ctor
        #endregion
        #region methods
        // Hinzufügen eines Regals
        public static void AddRegal(Regal regal)
        {
            _regale.Add(regal);
        }
        public static void Reorder(Artikel artikel)
        {
            artikel.BestandAendern(artikel, -artikel.Mindestbestand*2); // Der Wert muss negativ sein, da BestandAendern den Wert abzieht!
            Console.ForegroundColor = ConsoleColor.Green;
            Verwaltung.AddToLog($"Für den Artikel {artikel.Name} wurden {artikel.Mindestbestand*2} nachbestellt!\n");
            Console.ResetColor();
        }

        public static void BestandNiedrig(Artikel artikel) // Nachbestellen besteht aus der Benachrichtigung für den Besitzer, wird später in die LOG-Datei übertragen
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Verwaltung.AddToLog($"Der Bestand des Artikels {artikel.Name} liegt unter dem Mindestbestand!\n");
            Console.ResetColor();
        }
        #endregion
    }
}
