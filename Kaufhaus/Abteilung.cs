using System;
using System.Collections.Generic;
using System.Text;
/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
namespace Kaufhaus
{
    public class Abteilung
    {
        #region fields
        // Objektvariablen
        private readonly string _name;
        private readonly int _flaecheqm;
        private Abteilungsleiter _abteilungsleiter;
        private List<Artikel>? _artikelListe = new List<Artikel>();
        private List<Mitarbeiter>? _mitarbeiterListe = new List<Mitarbeiter>();
        #endregion

        #region properties
        // Getter-/Setter
        public Abteilungsleiter Leiter { get => _abteilungsleiter; }
        public List<Mitarbeiter>? Mitarbeiter { get => _mitarbeiterListe; }
        public List<Artikel>? Artikel { get => _artikelListe; }
        public string Name { get => _name; }
        public int Flaecheqm { get => _flaecheqm; }
        #endregion

        #region ctor
        // Konstruktor der Abteilung - Abteilungsleiter und Mitarbeiter sind ZWINGEND erforderlich!
        public Abteilung(string name, int flaecheqm, Abteilungsleiter abtleiter, Mitarbeiter ma1, Mitarbeiter ma2)
        {
            _name = name;
            _flaecheqm = flaecheqm;
            _artikelListe = new List<Artikel>();
            _abteilungsleiter = abtleiter;
            _abteilungsleiter.AddToAbteilung(this);
            ma1.AddToAbteilung(this);
            ma2.AddToAbteilung(this);
            _mitarbeiterListe.Add(ma1);
            _mitarbeiterListe.Add(ma2);
            Kaufhaus.AddAbteilung(this);
        }
        #endregion
        #region methods
        // Methoden zum Hinzufügen und Entfernen von Artikeln/Mitarbeitern sowie das ändern des Abteilungsleiters
        public void AddArtikel(Artikel artikel)
        {
            _artikelListe.Add(artikel);
        }
        public void RemoveArtikel(Artikel artikel)
        {
            _artikelListe.Remove(artikel);
        }
        public void AddMitarbeiter(Mitarbeiter ma)
        {
            _mitarbeiterListe.Add(ma);
        }
        public void RemoveMitarbeiter(Mitarbeiter ma)
        {
            _mitarbeiterListe.Remove(ma);
        }
        public void ChangeAbteilungsleiter(Abteilungsleiter neu) 
        {
            _abteilungsleiter = neu;
        }
        // AsString zu Debug-Zwecken
        public void AsString()
        {
            Console.WriteLine($"Abteilung: {_name,5}\n" +
                              $"Flaeche: {_flaecheqm,5}\n" +
                              $"Artikel:\n");
            for (int i = 0; i < _artikelListe.Count; i++)
            {
                Console.WriteLine($"{i}. {_artikelListe[i],5}");
            }
            Console.WriteLine($"\nAbteilungsleiter: {_abteilungsleiter, 5}\n");
            Console.WriteLine("Mitarbeiter: ");
            for (int i = 0; i < _mitarbeiterListe.Count; i++)
            {
                Console.WriteLine($"{i}. {_mitarbeiterListe[i],5}");
            }
                            
        }
        #endregion
    }
}
