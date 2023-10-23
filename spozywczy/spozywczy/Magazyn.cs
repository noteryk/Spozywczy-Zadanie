using spozywczy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace spozywczy
{
    // stworzenie klasy magazyn
    class Magazyn
    {

        // stworzenie wlasciwosci klasy magazyn i uzycie get set do pobierania i ustawiania wartosci zmiennych w klasie
        private string Nazwa {  get; set; }
        // stworzenie listy produktow w magazynie
        private List<Produkt> Produkty { get; set; }
        public Adres Adres { get; set; }
        
        // stworzenie konstruktora klasy magazyn
        public Magazyn(Adres adres, string nazwa)
        {
            Produkty = new List<Produkt>();
            Adres = adres;
            Nazwa = nazwa;
        }

        // stworzenie metody pobierajacej nazwe magazynu, aby moc ja wykorzystac w innych klasach
        public string PobierzNazwe()
        {
            return Nazwa;
        }


        // stworzenie metody pobierajacej produkty z magazynu, aby moc ja wykorzystac w innych klasach
        public List<Produkt> pobierzProdukty() {
            return Produkty;
        }


        // stworzenie metody dodajacej produkt do magazynu
        public void DodajProdukt(Produkt produkt)
        {
            Produkty.Add(produkt);
        }

        // stworzenie metody usuwajacej produkt z magazynu
        public void UsunProdukt(Produkt produkt)
        {
            Produkty.Remove(produkt);
        }


        // bez ponizszej linijki przy wywolaniu wszystkich magazynow dostalibysmy tylko napis magazyn.adres bez niczego
        public override string? ToString()
        {
            return "Nazwa magazynu: " + Nazwa + " Adres: " + Adres.Ulica;
        }


    }
}


