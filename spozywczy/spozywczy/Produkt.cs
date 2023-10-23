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
    private string NazwaProducent { get; set; }
    private string NazwaProduktu { get; set; }
    private string Kategoria { get; set; }
    private int KodProduktu { get; set; }
    private decimal Cena { get; set; }

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


        public string PobierzNazweProduktu()
        {
            return NazwaProduktu;
        }

        public string PobierzNazweProducenta()
        {
            return NazwaProducent;
        }


        public decimal PobierzCene()
        {
            return Cena;
        }
        public override string? ToString()
        {
            return "nazwa produktu: " + NazwaProduktu + " cena: " + Cena;
        }
    }

}
