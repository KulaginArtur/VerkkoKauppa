using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkkoKauppa;

namespace Projekti
{
    class Program
    {
        protected static void Main(string[] args)
        {
            const string tallennusSijainti = @"/Users/artur/Documents/development-team-10/AsiakasSivu/";
            const string tiedostoPolkuTilaus = tallennusSijainti + "tilaus.csv";
            const string tiedostoPolkuVarasto = tallennusSijainti + "varasto.csv";
            const string tiedostoPolkuVahvistetut = tallennusSijainti + "vahvistetut.csv";


            Tilaus tilaus = new Tilaus();
            Tulostaja tulostaja = new Tulostaja();
            // Kysytään käyttäjältä kummalle sivulle hän haluaa.


            tulostaja.KäyttäjäValinta();

            // Tallentaa käyttäjän vastauksen
            string alku = Console.ReadLine();

            List<Tilausrivi> tilausrivit = new List<Tilausrivi>();

            switch (alku)
            {
                case "1":
                    {

                        bool tuotteidenLisäys = true;

                        // Ohjelma toimii niin pitkään kunnes käyttäjä valitsee että haluaa poistua
                        while (tuotteidenLisäys)
                        {
                            tulostaja.AsiakasToiminto();

                            // Odotetaan vastausta käyttäjältä
                            string vastaus = Console.ReadLine();
                            Console.Clear();

                            switch (vastaus)
                            {
                                case "1": // Toiminto kysyy käyttäjältä mitä lisätään ostoskoriin
                                    {
                                        // Haetaan tuotteet varasto.csv tiedostosta

                                        string[] csvTuoterivit = System.IO.File.ReadAllLines(tiedostoPolkuVarasto);


                                        // Luodaan lista tuotteille
                                        List<Tuote> tuotelista = new List<Tuote>();

                                        foreach (string rivi in csvTuoterivit)
                                        {

                                            string[] pilkottuRivi = rivi.Split(';');
                                            Tuote tuote = new Tuote
                                            {
                                                Tuotenumero = Int32.Parse(pilkottuRivi[0]),
                                                Tuotenimi = pilkottuRivi[1],
                                                Hinta = Double.Parse(pilkottuRivi[2]),
                                                Kpl = Int32.Parse(pilkottuRivi[3])
                                            };

                                            tuotelista.Add(tuote);
                                        }

                                        tulostaja.TuoteSivunOtsikko();

                                        for (int i = 0; i < tuotelista.Count(); i++)
                                        {
                                            // Haetaan listalta tuote
                                            Tuote listallaOlevaTuote = tuotelista[i];

                                            // Muodostetaan haluttu tuloste
                                            int tunniste = i + 1;
                                            string tuloste = $"{ tunniste}\t\t{listallaOlevaTuote.Tuotenumero}\t\t{listallaOlevaTuote.Tuotenimi}\t{listallaOlevaTuote.Hinta}";

                                            // Näytä muodostettu tuloste
                                            Console.WriteLine(tuloste);
                                        }

                                        // Tiedon hakeminen listatsta syötteen perusteella
                                        tulostaja.AsiakkaanTuoteValinta();

                                        int valittuTunniste = Int32.Parse(Console.ReadLine());

                                        Tuote valittuTuote = tuotelista[valittuTunniste - 1];

                                        Console.WriteLine($"\nValitsit tuotteen:\n{valittuTunniste}\t\t{valittuTuote.Tuotenumero}\t\t{valittuTuote.Tuotenimi}\t{valittuTuote.Hinta}\n");

                                        // Käyttäjän valitsema määrä
                                        tulostaja.KappaleMäärä();

                                        var num1 = Console.ReadLine();
                                        int kplMäärä = int.Parse(num1);

                                        Tuote valittuTuote3 = tuotelista[valittuTunniste - 1];
                                        valittuTuote3.Kpl = kplMäärä;
                                        Tilausrivi tilausrivi = new Tilausrivi
                                        {
                                            // Tilauksen tallennus luokkaan
                                            Tuotenimi = valittuTuote.Tuotenimi,
                                            Tuotenumero = valittuTuote.Tuotenumero,
                                            Hinta = valittuTuote.Hinta,
                                            Kpl = valittuTuote3.Kpl
                                        };

                                        tilausrivit.Add(tilausrivi);

                                        tulostaja.Poistu();
                                        Console.ReadLine();
                                        break;
                                    }


                                // Ohjelma näyttää kaikki tuotteet ja antaa mahdollisuuden muokata tilausta.
                                case "2":
                                    {
                                        tulostaja.MuokkauksenYläRivi();

                                        for (int i = 0; i < tilausrivit.Count(); i++)
                                        {
                                            // Haetaan listalta tuote
                                            Tilausrivi listallaOlevaTuote = tilausrivit[i];

                                            // Muodostetaan haluttu tuloste
                                            string tuloste = $"{listallaOlevaTuote.Tuotenumero}\t\t{listallaOlevaTuote.Tuotenimi}\t{listallaOlevaTuote.Hinta}\t\t{listallaOlevaTuote.Kpl}";

                                            // Näytä muodostettu tuloste
                                            Console.WriteLine(tuloste);
                                        }

                                        tulostaja.TuotteidenMuokkausValinta();

                                        var toiminto = Console.ReadLine();
                                        switch (toiminto)
                                        {
                                            case "1":
                                                {
                                                    tulostaja.TuotteenValinta();

                                                    for (int i = 0; i < tilausrivit.Count(); i++)
                                                    {
                                                        // Haetaan listalta tuote
                                                        Tilausrivi listallaOlevaTuote = tilausrivit[i];

                                                        // Muodostetaan haluttu tuloste
                                                        int tunniste = i + 1;
                                                        string tuloste = $"{tunniste}\t\t{listallaOlevaTuote.Tuotenumero}\t\t{listallaOlevaTuote.Tuotenimi}\t{listallaOlevaTuote.Hinta}\t\t{listallaOlevaTuote.Kpl}";

                                                        // Näytä muodostettu tuloste
                                                        Console.WriteLine(tuloste);
                                                    }

                                                    tulostaja.AsiakkaanTuoteValinta();
                                                    var PT = Console.ReadLine();
                                                    int poistettavaTuote = int.Parse(PT);
                                                    tilausrivit.RemoveAt(poistettavaTuote - 1);
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    tilausrivit.Clear();
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    tulostaja.Poistu();
                                                    Console.ReadLine();
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                        break;
                                    }



                                // Yhteystiedot ja tilauksen vahvistus
                                case "3":
                                    {

                                        Tulostaja tulostaja1 = new Tulostaja();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Etunimi();
                                        string etunimi = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Sukunimi();
                                        string sukunimi = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Puhelinnumero();
                                        string puhelinnumero = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Kotiosoite();
                                        var kotiosoite = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Postinumero();
                                        var postinumero = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Kaupunki();
                                        var kaupunki = Console.ReadLine();

                                        tulostaja1.PystytMuokkaamaan();
                                        tulostaja1.Sähköposti();
                                        var säköosti = Console.ReadLine();

                                        Console.Clear();

                                        bool content = true;

                                        while (content)
                                        {
                                            Console.WriteLine("Yhteystietosi:\n");
                                            Console.WriteLine("Etunimi: " + etunimi);
                                            Console.WriteLine("Sukunimi: " + sukunimi);
                                            Console.WriteLine("Puhelinnumero: " + puhelinnumero);
                                            Console.WriteLine("Kotiosoite: " + kotiosoite);
                                            Console.WriteLine("Postinumero: " + postinumero);
                                            Console.WriteLine("Kaupunki: " + kaupunki);
                                            Console.WriteLine("Säköostiosoite: " + säköosti);

                                            tulostaja1.YhteystietojenMuokkaus();

                                            var vastaus2 = Console.ReadLine();

                                            switch (vastaus2)
                                            {
                                                case "1":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Etunimi();
                                                        string uusietunimi = Console.ReadLine();
                                                        etunimi = uusietunimi;

                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "2":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Sukunimi();

                                                        string uusisukunimi = Console.ReadLine();
                                                        sukunimi = uusisukunimi;
                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "3":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Puhelinnumero();

                                                        string uusipuhelinnumero = Console.ReadLine();
                                                        puhelinnumero = uusipuhelinnumero;
                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "4":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Kotiosoite();

                                                        string uusikotiosoite = Console.ReadLine();
                                                        kotiosoite = uusikotiosoite;
                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "5":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Postinumero();

                                                        string uusipostinumero = Console.ReadLine();
                                                        postinumero = uusipostinumero;
                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "6":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Kaupunki();

                                                        string uusikaupunki = Console.ReadLine();
                                                        kaupunki = uusikaupunki;
                                                        Console.Clear();

                                                        break;
                                                    }
                                                case "7":
                                                    {
                                                        Console.Clear();
                                                        tulostaja1.Sähköposti();

                                                        string uusisäköosti = Console.ReadLine();
                                                        säköosti = uusisäköosti;
                                                        Console.Clear();

                                                        break;
                                                    }

                                                case "8":
                                                    {
                                                        //Tilauksen tallennus
                                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(tiedostoPolkuTilaus, true))
                                                        {
                                                            for (int i = 0; i < tilausrivit.Count(); i++)
                                                            {
                                                                //Haetaan listalta tuote
                                                                Tilausrivi listallaOlevaTuote = tilausrivit[i];


                                                                // Muodostetaan haluttu tuloste
                                                                string tuloste = $"{listallaOlevaTuote.Tuotenumero} ; {listallaOlevaTuote.Tuotenimi} ; {listallaOlevaTuote.Hinta} ; {listallaOlevaTuote.Kpl};{ etunimi} ; { sukunimi} ; { puhelinnumero} ; { kotiosoite} ; { postinumero} ; { kaupunki} ; { säköosti}";

                                                                // Näytä muodostettu tuloste
                                                                file.WriteLine(tuloste);
                                                            }
                                                            content = false;

                                                            break;
                                                        }
                                                    }
                                            }
                                        }
                                        tulostaja1.TilauskenVahvistus();
                                        Console.ReadLine();
                                        tuotteidenLisäys = false;


                                        break;

                                    }

                                // Käyttäjä sulkee ohjelman
                                case "4":
                                    {
                                        tuotteidenLisäys = false;
                                        break;
                                    }
                            }
                        }
                        break;
                    }

                case "2":
                    {
                        bool Vaihtoehdot = true;
                        while (Vaihtoehdot)
                        {
                            tulostaja.MyyjänValinnat();

                            string valinta = Console.ReadLine();
                            Console.Clear();
                            switch (valinta)
                            {

                                case "1":
                                    {
                                       //lukee tilauksen
                                        string[] csvVarasto1 = System.IO.File.ReadAllLines(tiedostoPolkuTilaus);//polku office tiedostoon


                                        List<Tuote> Varasto1 = new List<Tuote>();

                                        foreach (string rivi in csvVarasto1)
                                        {
                                            string[] pilkottuRivi = rivi.Split(';');
                                            Tuote tuote = new Tuote
                                            {
                                                Tuotenumero = Int32.Parse(pilkottuRivi[0]),
                                                Tuotenimi = pilkottuRivi[1],
                                                Hinta = Double.Parse(pilkottuRivi[2]),

                                                Kpl = Int32.Parse(pilkottuRivi[3]),
                                                Nimi2 = pilkottuRivi[4],
                                                Sukunimi2 = pilkottuRivi[5],
                                                Numero2 = Int32.Parse(pilkottuRivi[6]),
                                                Kotiosoite2 = pilkottuRivi[7],
                                                Postinumero2 = Int32.Parse(pilkottuRivi[8]),
                                                Kaupunki2 = pilkottuRivi[9],
                                                Sähköpostiosoite2 = pilkottuRivi[10]
                                            };

                                            Varasto1.Add(tuote);
                                        }

                                        // Tilauksien tekijöiden yhteystiedot
                                        tulostaja.TilausOtsikko1();

                                        for (int i = 0; i < Varasto1.Count(); i++)
                                        {
                                            Tuote listallaOlevaTuote = Varasto1[i];

                                            int tunniste = i + 1;
                                            string tuloste = $"{ tunniste}\t\t{listallaOlevaTuote.Nimi2}\t{listallaOlevaTuote.Sukunimi2}\t{listallaOlevaTuote.Numero2}\t{listallaOlevaTuote.Kotiosoite2}\t\t{listallaOlevaTuote.Postinumero2}\t\t{listallaOlevaTuote.Kaupunki2}\t{listallaOlevaTuote.Sähköpostiosoite2}";

                                            Console.WriteLine(tuloste);
                                        }

                                        // Tilatut tuotteet
                                        tulostaja.TilausOtsikko2();


                                        for (int i = 0; i < Varasto1.Count(); i++)
                                        {
                                            Tuote listallaOlevaTuote = Varasto1[i];

                                            int tunniste = i + 1;
                                            string tuloste = $"{ tunniste}\t\t{listallaOlevaTuote.Tuotenumero}\t\t{ listallaOlevaTuote.Tuotenimi}\t{ listallaOlevaTuote.Hinta}\t\t{listallaOlevaTuote.Kpl}\t";//{listallaOlevaTuote.Nimi2}\t{listallaOlevaTuote.Sukunimi2}\t{listallaOlevaTuote.Numero2}{listallaOlevaTuote.Kotiosoite2}\t{listallaOlevaTuote.Postinumero2}\t{listallaOlevaTuote.Kaupunki2}\t{listallaOlevaTuote.Sähköpostiosoite2}";//määrää jäjestyksen tulostettaville tiedoille

                                            Console.WriteLine(tuloste);
                                        }


                                            tulostaja.TilauksenKäsittely();

                                            string teksti1 = Console.ReadLine();
                                            switch (teksti1)
                                            {
                                            case "1":
                                                {
                                                    break;
                                                }

                                            case "2":
                                                    {
                                                        tulostaja.TilauksenTunniste();

                                                        int valittuTunnistev = Int32.Parse(Console.ReadLine());
                                                        //näyttää tuotteen jonka haluat lähettää
                                                        Tuote valittuTuote = Varasto1[valittuTunnistev - 1];
                                                        Console.WriteLine($"Tuote jonka valitsit:{ valittuTuote}\t\t{valittuTuote.Tuotenumero}\t\t{ valittuTuote.Tuotenimi}\t{ valittuTuote.Hinta}\t{valittuTuote.Kpl}\n\n");
                                                        //näyttää varaston tilan
                                                        string[] csvVarasto = System.IO.File.ReadAllLines(tiedostoPolkuVarasto);//polku office tiedostoon
                                                        List<Tuote> Varasto = new List<Tuote>();

                                                    foreach (string rivi in csvVarasto)
                                                    {
                                                        string[] pilkottuRivi = rivi.Split(';');
                                                        Tuote tuote = new Tuote
                                                        {
                                                            Tuotenumero = Int32.Parse(pilkottuRivi[0]),
                                                            Tuotenimi = pilkottuRivi[1],
                                                            Hinta = Double.Parse(pilkottuRivi[2]),
                                                            Kpl = Int32.Parse(pilkottuRivi[3])
                                                        };

                                                        Varasto.Add(tuote);
                                                    }
                                                        
                                                        tulostaja.TilausOtsikko();
                                                        for (int i = 0; i < Varasto.Count(); i++)
                                                        {
                                                            Tuote listallaOlevaTuote = Varasto[i];

                                                            int tunniste = i + 1;
                                                            string tuloste = $"{ tunniste}\t\t{listallaOlevaTuote.Tuotenumero}\t\t{ listallaOlevaTuote.Tuotenimi}\t{ listallaOlevaTuote.Hinta}\t{listallaOlevaTuote.Kpl}";

                                                            Console.WriteLine(tuloste);
                                                        }
                                                        tulostaja.VähennettäväTuote();
                                                        
                                                        //luetaan tunniste
                                                        int valittuTunniste = Int32.Parse(Console.ReadLine());

                                                        Tuote valittuTuote1 = Varasto[valittuTunniste - 1];


                                                        //lasketaan uusi kpl määrä
                                                        Tuote valittuTuote2 = Varasto[valittuTunniste - 1];
                                                        valittuTuote2.Kpl = valittuTuote2.Kpl - valittuTuote.Kpl;
                                                        //miinustaa varastosta tilatun tuotteen
                                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(tiedostoPolkuVarasto))//polku office tiedostoon
                                                        {
                                                            foreach (Tuote tuote in Varasto)
                                                            {

                                                                string csvRivi = $"{tuote.Tuotenumero};{tuote.Tuotenimi};{tuote.Hinta};{tuote.Kpl}";
                                                                file.WriteLine(csvRivi);

                                                            }

                                                        }

                                                        using (System.IO.StreamWriter file1 = new System.IO.StreamWriter(tiedostoPolkuVahvistetut, true))//polku office tiedostoon
                                                        {
                                                            //tallennus uuteen paikkaan eli käsiteltyihin tilauksiin
                                                            string csvRivi = $"{valittuTuote.Tuotenumero};{valittuTuote.Tuotenimi};{valittuTuote.Hinta};{valittuTuote.Kpl}";
                                                            file1.WriteLine(csvRivi);

                                                        }
                                                        //Poisto tiluksesta mitäs vittua tä
                                                        using (System.IO.StreamWriter file1 = new System.IO.StreamWriter(tiedostoPolkuTilaus, true))
                                                        {

                                                        }

                                                        tulostaja.Poistu();
                                                        Console.ReadLine();
                                                        break;

                                                    }
                                            }
                                            break;

                                    }

                                //varasto

                                case "2":
                                    {
                                        //varasto
                                        string[] csvVarasto = System.IO.File.ReadAllLines(tiedostoPolkuVarasto);//polku office tiedostoon
                                        List<Tuote> Varasto = new List<Tuote>();

                                        foreach (string rivi in csvVarasto)
                                        {
                                            string[] pilkottuRivi = rivi.Split(';');
                                            Tuote tuote = new Tuote
                                            {
                                                Tuotenumero = Int32.Parse(pilkottuRivi[0]),
                                                Tuotenimi = pilkottuRivi[1],
                                                Hinta = Double.Parse(pilkottuRivi[2]),
                                                Kpl = Int32.Parse(pilkottuRivi[3])
                                            };

                                            Varasto.Add(tuote);
                                        }

                                        tulostaja.TilausOtsikko();

                                        for (int i = 0; i < Varasto.Count(); i++)
                                        {
                                            Tuote listallaOlevaTuote = Varasto[i];

                                            int tunniste = i + 1;
                                            string tuloste = $"{ tunniste}\t\t{listallaOlevaTuote.Tuotenumero}\t\t{ listallaOlevaTuote.Tuotenimi}\t{ listallaOlevaTuote.Hinta}\t{listallaOlevaTuote.Kpl}";

                                            Console.WriteLine(tuloste);
                                        }

                                        tulostaja.LisättäväTuote();


                                        int valittuTunniste = Int32.Parse(Console.ReadLine());

                                        Tuote valittuTuote = Varasto[valittuTunniste - 1];
                                        Console.WriteLine($"\nValittu tuote:\n{valittuTunniste}\t\t{valittuTuote.Tuotenumero}\t\t{ valittuTuote.Tuotenimi}\t{ valittuTuote.Hinta}\t");
                                        Console.WriteLine($"\nTuotteen kappale määrä tällä hetkellä: {valittuTuote.Kpl}");
                                        tulostaja.KappaleMäärä();

                                        var num = Console.ReadLine();
                                        int kpl1 = int.Parse(num);

                                        // Lasketaan uusi tuotemäärä.
                                        Tuote valittuTuote2 = Varasto[valittuTunniste - 1];
                                        valittuTuote2.Kpl = valittuTuote2.Kpl + kpl1;

                                        tulostaja.Tallennus();
                                        string teksti5 = Console.ReadLine();
                                        if (teksti5.ToLower().Contains("k"))
                                        {

                                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(tiedostoPolkuVarasto))//polku office tiedostoon
                                            {
                                                foreach (Tuote tuote in Varasto)
                                                {

                                                    string csvRivi = $"{tuote.Tuotenumero};{tuote.Tuotenimi};{tuote.Hinta};{tuote.Kpl}";
                                                    file.WriteLine(csvRivi);

                                                }
                                                tulostaja.Tallennettu();
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                        }


                                        if (teksti5.ToLower().Contains("e"))
                                        {
                                            Console.Clear();
                                            break;
                                        }


                                    }
                                    break;


                                // Kun myyjä valitsee poistumisen

                                case "3":
                                    tulostaja.Poistuit();
                                    Vaihtoehdot = false;

                                    break;
                            }
                        }
                        break;
                    }
            }
        }
    }
}