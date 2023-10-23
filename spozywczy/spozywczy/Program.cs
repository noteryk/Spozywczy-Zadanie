

// Importowanie bibliotek
using spozywczy;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

// Utworzenie list dla magazynow, produktow i adresow
Console.WriteLine("Panel Zarzadzania");
List<Magazyn> magazyny = new List<Magazyn>();
List<Produkt> produkty = new List<Produkt>();
List<Adres> adresy = new List<Adres>();


// For loop aby program dzialal w nieskonczonosc
for (; ; )
{
    Console.WriteLine("Wybierz jedna z opcji: ");
    Console.WriteLine("1. Dodaj magazyn \n2. Edytuj Magazyn \n3. Usun magazyn \n4. Dodaj produkt \n5. Edytuj produkt \n6. Usun produkt \n7. Dodaj produkt do magazynu \n8. Usun produkt z magazynu \n9. Wyjscie");
    Console.WriteLine("Twoj wybor: ");
    // Instrukcja switch wykorzytujaca GetNumber, aby sprawdzic czy uzytkownik podal liczbe i czy jest ona w zakresie od 1 do 9
    switch (GetNumber())
    {
        case 1:
            // Wywolanie metody dodaj magazyn i wyczyszczenie konsoli
            // If uzyty po to aby zwrocilo wartosc true lub false, wtedy GetNumber sprawdza czy nie wyszlismy poza zakres
            if (DodajMagazyn()) Console.Clear();
            break;
        case 2:
            if (EdytujMagazyn()) Console.Clear();
            break;
        case 3:
            if (UsunMagazyn()) ;
            break;
        case 4:
            if (DodajProdukt()) ;
            break;
        case 5:
            if (EdytujProdukt()) ;
            break;
        case 6:
            if (UsunProdukt()) ;
            break;
        case 7:
            if (DodajProduktMagazyn()) ;
            break;
        case 8:
            if (UsunProduktMagazyn()) ;
            break;
        case 9:
            // Wyjscie z programu poprzez environment.exit
            Console.WriteLine("Dziekuje za skorzystanie z programu, do zobaczenia");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Nie ma takiego wyboru. Sprobuj ponownie.");
            break;
    }

    // Metoda dodajaca magazyn i uzupelniajaca go danymi
    bool DodajMagazyn()
    {
        // Try catch aby zlapac bledy i wypisac je jako tekst, aby uniknac wyrzucenia programu
        try
        {
            Console.WriteLine("Podaj dane magazynu:");

            Console.Write("Nazwa magazynu: ");
            // Pobranie nazwy magazynu
            string nazwaMagazynu = Console.ReadLine();

            Console.Write("Ulica: ");
            string ulica = Console.ReadLine();
            Console.Write("Kod pocztowy: ");
            string kodPocztowy = Console.ReadLine();
            Console.Write("Miejscowość: ");
            string miejscowosc = Console.ReadLine();

            int numerPosesji;
            try
            {
                Console.Write("Numer posesji: ");
                // Konwersja typu ze string na int numeru posesji
                numerPosesji = Convert.ToInt32(Console.ReadLine());
            }
            // Wyrzucenie bledu gdy uzytkownik poda zly format
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format numeru posesji.");
                return false;
            }

            int numerLokalu;
            try
            {
                Console.Write("Numer lokalu: ");
                numerLokalu = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format numeru lokalu.");
                return false;
            }

            // Utworzenie obiektu adresu i uzupelnienie go danymi
            Adres adres = new Adres(ulica, kodPocztowy, miejscowosc, numerPosesji, numerLokalu);
            // Utworzenie obiektu magazynu i uzupelnienie go danymi
            Magazyn magazyn = new Magazyn(adres, nazwaMagazynu);
            // Dodanie poprzednich danych do magazynu
            magazyny.Add(magazyn);
            Console.WriteLine("Magazyn dodany.");

            return true;
        }
        catch (Exception ex)
        // Wypisanie błędu jako tekst 
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }


    // Metoda edytujaca magazyn i uzupelniajaca go nowymi danymi
    bool EdytujMagazyn()
    {
        try
        {
            Console.WriteLine("Twoje magazyny: ");
            // Wywolanie metody wyswietlajacej magazyny, aby uzytkownik mogl wybrac ktory chce edytowac wczesniej
            WyswietlMagazyny();
            Console.WriteLine("Podaj indeks magazynu do edycji: ");
            // Sprawdzenie czy indeks jest prawidłowy
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < magazyny.Count)
            {
                Console.WriteLine("Podaj nowe dane magazynu:");
                Console.Write("Ulica: ");
                string ulica = Console.ReadLine();
                Console.Write("Kod pocztowy: ");
                string kodPocztowy = Console.ReadLine();
                Console.Write("Miejscowość: ");
                string miejscowosc = Console.ReadLine();

                int numerPosesji;
                try
                {
                    Console.Write("Numer posesji: ");
                    numerPosesji = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nieprawidłowy format numeru posesji.");
                    return false;
                }

                int numerLokalu;
                try
                {
                    Console.Write("Numer lokalu: ");
                    numerLokalu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nieprawidłowy format numeru lokalu.");
                    return false;
                }

                // utworzenie obiektu adresu i uzupelnienie go danymi
                Adres adres = new Adres(ulica, kodPocztowy, miejscowosc, numerPosesji, numerLokalu);
                magazyny[index].Adres = adres;
                Console.WriteLine("Magazyn zaktualizowany.");

                return true;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks magazynu.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }


    // Metoda usuwajaca magazyn
    bool UsunMagazyn()
    {
        try
        {
            Console.WriteLine("Twoje magazyny: ");
            WyswietlMagazyny();
            Console.WriteLine("Podaj indeks magazynu do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < magazyny.Count)
            {
                magazyny.RemoveAt(index);
                Console.WriteLine("Magazyn usunięty.");
                return true;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks magazynu.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }

    // Metoda dodajaca produkt
    bool DodajProdukt()
    {
        try
        {

            Console.WriteLine("Podaj informacje o produkcie: ");
            Console.Write("Producent: ");
            string nazwaProducenta = Console.ReadLine();
            Console.Write("Nazwa: ");
            string nazwaProduktu = Console.ReadLine();
            Console.Write("Kategoria: ");
            string kategoria = Console.ReadLine();

            int kodProduktu;

            try
            {
                Console.Write("Kod produktu: ");
                kodProduktu = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format kodu produktu.");
                return false;
            }

            Console.Write("Cena: ");
            // Sprawdza czy cena jest prawidłowa i czy jest typu decimal
            if (decimal.TryParse(Console.ReadLine(), out decimal cena))
            {
                Console.Write("Opis: ");
                string opis = Console.ReadLine();

                Produkt produkt = new Produkt(nazwaProducenta, nazwaProduktu, kategoria, kodProduktu, cena, opis);
                produkty.Add(produkt);
                Console.WriteLine("Produkt dodany.");

                return true;
            }
            else
            {
                Console.WriteLine("Nieprawidlowe dane.");
                return false;
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }


    // Metoda edytujaca produkt
    bool EdytujProdukt()
    {
        try
        {
            Console.WriteLine("Utworzone produkty: ");
            WyswietlProdukty();

            Console.WriteLine("Podaj indeks produktu do edycji: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < produkty.Count)
            {
                Console.WriteLine("Podaj nowe dane produktu:");
                Console.Write("Producent: ");
                string nazwaProducenta = Console.ReadLine();
                Console.Write("Nazwa: ");
                string nazwaProduktu = Console.ReadLine();
                Console.Write("Kategoria: ");
                string kategoria = Console.ReadLine();
                int kodProduktu;
                try
                {
                    Console.Write("Kod produktu: ");
                    kodProduktu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nieprawidłowy format kodu produktu.");
                    return false;
                }
                Console.Write("Cena: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal cena))
                {
                    Console.Write("Opis: ");
                    string opis = Console.ReadLine();

                    Produkt produkt = new Produkt(nazwaProducenta, nazwaProduktu, kategoria, kodProduktu, cena, opis);
                    produkty[index] = produkt;
                    Console.WriteLine("Produkt zaktualizowany.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa cena.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks produktu.");
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }

    // Metoda usuwajaca produkt
    bool UsunProdukt()
    {
        try

        {
            Console.WriteLine("Utworzone produkty: ");
            WyswietlProdukty();
            Console.WriteLine("Podaj indeks produktu do usunięcia: ");
            // Sprawdza czy indeks jest prawidłowy
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < produkty.Count)
            {
                produkty.RemoveAt(index);
                Console.WriteLine("Produkt usunięty.");
                return true;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks produktu.");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Wypisuje błąd jako tekst
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }


    // metoda dodajaca produkt do magazynu
    bool DodajProduktMagazyn()
    {
        try
        {
            // wyswietlenie informacji i list produktow w magazynach
            Console.WriteLine("-----------");
            Console.WriteLine("Twoje produkty w magazynach:");
            WyswietlProduktyMagazyn();
            Console.WriteLine("-----------");
            Console.WriteLine("Podaj indeks magazynu:");
            int userinputIndex = ReadUserNumber();
            // pobranie magazynu po indeksie
            Magazyn magazyn = getMagazynByIndex(userinputIndex);

            // wyswietlenie informacji i list produktow
            Console.WriteLine("-----------");
            Console.WriteLine("Twoje produkty:");
            WyswietlProdukty();
            Console.WriteLine("-----------");

            // wybor produktu do dodania do magazynu i dodanie go
            Console.WriteLine("Podaj indeks produktu do dodania do magazynu:");
            int productIndex = ReadUserNumber();

            Produkt produkt = getProductByIndex(productIndex);
            magazyn.DodajProdukt(produkt);

            Console.WriteLine("Produkt dodany do magazynu.");


            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }




    bool UsunProduktMagazyn()
    {
        try
        {
            // wyswietlenie informacji i list produktow w magazynach
            Console.WriteLine("-----------");
            Console.WriteLine("Twoje produkty w magazynach:");
            WyswietlProduktyMagazyn();
            Console.WriteLine("-----------");
            Console.WriteLine("Podaj indeks magazynu:");
            int userinputIndex = ReadUserNumber();
            // pobranie magazynu po indeksie
            Magazyn magazyn = getMagazynByIndex(userinputIndex);

            // wyswietlenie informacji i list produktow
            Console.WriteLine("-----------");
            Console.WriteLine("Twoje produkty:");
            WyswietlProdukty();
            Console.WriteLine("-----------");

            // wybor produktu do usuniecia z magazynu
            Console.WriteLine("Podaj indeks produktu do usuniecia z magazynu:");
            int productIndex = ReadUserNumber();

            Produkt produkt = getProductByIndex(productIndex);
            magazyn.UsunProdukt(produkt);

            Console.WriteLine("Produkt usuniety z magazynu.");


            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.ToString());
            return false;
        }
    }

    // sprawdza czy indeks jest prawidłowy i zwraca magazyn na podstawie indeksu
    Magazyn getMagazynByIndex(int index)
    {
        if (index >= 0 && index < magazyny.Count)
        {
            return magazyny[index];
        }
        else
        {
            throw new Exception("Nieprawidłowy indeks magazynu.");
        }
    }

    // sprawdza czy indeks jest prawidłowy i zwraca produkt na podstawie indeksu
    Produkt getProductByIndex(int index)
    {
        if (index >= 0 && index < produkty.Count)
        {
            return produkty[index];
        }
        else
        {
            throw new Exception("Nieprawidłowy indeks produktu.");
        }
    }


    // metoda wyswietlajaca magazyny
    void WyswietlMagazyny()
    {
        foreach (var magazyn in magazyny)
        {
            Console.WriteLine(magazyn);
        }
    }
}

// metoda wyswietlajaca produkty 
void WyswietlProdukty()
{
    foreach (var produkty in produkty)
    {
        Console.WriteLine(produkty);
    }
}

// metoda wyswietlajaca produkty w magazynie
void WyswietlProduktyMagazyn()
{
    // sprawdza czy mamy magazyny utworzone
    if (magazyny.Count == 0)
    {
        Console.WriteLine("Nie masz magazynów");
        return;
    }


    for (int i = 0; i < magazyny.Count; i++)
    {
        // sprawdza czy magazyn ma produkty
        Magazyn? magazyn = magazyny[i];
        if (magazyn.pobierzProdukty().Count == 0)
        {
            Console.WriteLine("Magazyn " + magazyn.PobierzNazwe() + " nie ma produktów");
            continue;
        }

        // wyswietla produkty w magazynie
        for (int i1 = 0; i1 < magazyn.pobierzProdukty().Count; i1++)
        {
            Produkt? produkt = magazyn.pobierzProdukty()[i1];
            Console.WriteLine("Indeks: " + i1 + " | Produkt " + produkt.PobierzNazweProduktu() + " (" + produkt.PobierzNazweProducenta() + ") w magazynie " + magazyn.PobierzNazwe() + " o indeksie: " + i + " | Cena: " + produkt.PobierzCene());
        }

    }
}


// metoda sprawdzajaca czy uzytkownik podal liczbe i czy jest ona w zakresie od 1 do 9
int GetNumber()
{
    int zm = 0;
    try
    {
        return Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        return -1;
    }
}

//sprawdza czy uzytkownik na pewno podal liczbe 
int ReadUserNumber()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Nieprawidlowy format liczby. Sprobuj ponownie.");
    }
    return number;
}

