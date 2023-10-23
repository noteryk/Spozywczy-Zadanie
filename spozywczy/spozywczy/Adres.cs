using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spozywczy
{
    // stworzenie klasy adres
    class Adres
    {
        // stworzenie wlasciwosci klasy adres i uzycie get set do pobierania i ustawiania wartosci zmiennych w klasie
        public string Ulica { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public int NumerPosesji { get; set; }
        public int NumerLokalu { get; set; }

        // konstruktor klasy adres z parametrami ktore musza byc podane przy tworzeniu obiektu klasy adres
        public Adres(string ulica, string kodPocztowy, string miejscowosc, int numerPosesji, int numerLokalu)
        {
            // przypisanie wartosci zmiennym w klasie adres 
            Ulica = ulica;
            KodPocztowy = kodPocztowy;
            Miejscowosc = miejscowosc;
            NumerPosesji = numerPosesji;
            NumerLokalu = numerLokalu;
        }
    }
}
