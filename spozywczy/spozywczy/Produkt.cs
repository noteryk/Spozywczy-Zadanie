using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spozywczy
{

    // stworzenie klasy produkt
class Produkt
{

// stworzenie wlasciwosci klasy produkt i uzycie get set do pobierania i ustawiania wartosci zmiennych w klasie
    public string NazwaProducent { get; set; }
    public string NazwaProduktu { get; set; }
    public string Kategoria { get; set; }
    public int KodProduktu { get; set; }
    public decimal Cena { get; set; }

    public string Opis { get; set; }


    // stworzenie konstruktora klasy produkt zawierajacego parametry ktore musza byc podane przy tworzeniu obiektu klasy produkt
    public Produkt(string nazwaProducenta, string nazwaProduktu, string kategoria, int kodProduktu, decimal cena, string opis)
    {
        NazwaProducent = nazwaProducenta;
        NazwaProduktu = nazwaProduktu;
        Kategoria = kategoria;
        KodProduktu = kodProduktu;
        Cena = cena;
        Opis = opis;
    }

       
        public override string? ToString()
        {
            return "nazwa produktu: " + NazwaProduktu + " cena: " + Cena;
        }
    }
}
