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
        private string KodPocztowy { get; set; }
        private string Miejscowosc { get; set; }
        private string NumerPosesji { get; set; }
        private string NumerLokalu { get; set; }

        // konstruktor klasy adres z parametrami ktore musza byc podane przy tworzeniu obiektu klasy adres
        public Adres(string ulica, string kodPocztowy, string miejscowosc, string numerPosesji, string numerLokalu)
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
