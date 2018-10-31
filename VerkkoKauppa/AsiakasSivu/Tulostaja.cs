using System;
namespace VerkkoKauppa
{
    public class Tulostaja
    {
        public Tulostaja()
        {
        }

        //  PÄÄOHJELMA
        public void KäyttäjäValinta()
        {
            Console.WriteLine("Valitse kumpi olet:\n[ 1 ] Asiakas\n[ 2 ] Myyjä");
        }

        public void AsiakasToiminto()
        {
            Console.Clear();

            // Kysytään mitä käyttäjä haluaa tehdä.
            Console.WriteLine("Mitä haluat tehdä? ");
            Console.WriteLine("[ 1 ] Tuotteen lisäys.");
            Console.WriteLine("[ 2 ] Tilauksen tarkistus ja muokkaus.");
            Console.WriteLine("[ 3 ] Tilauksen vahvistus.");
            Console.WriteLine("[ 4 ] Poistu ohjelmasta.");
        }

        public void TuoteSivunOtsikko()
        {
            Console.WriteLine("Tunniste\tTuotenumero\tTuotenimi\t\t\tHinta");
        }

        public void AsiakkaanTuoteValinta()
        {
            Console.WriteLine("Anna tuotteen tunniste.");
        }

        public void KappaleMäärä()
        {
            Console.WriteLine("Kuinka monta kpl:");
        }

        public void MuokkauksenYläRivi()
        {
            Console.WriteLine("Tuotenumero\tTuotenimi\t\t\tHinta\t\tKpl");
        }

        public void TuotteidenMuokkausValinta()
        {
            Console.WriteLine("\n\nValitse mitä haluat tehdä.");
            Console.WriteLine("[ 1 ] Tuotteen poisto");
            Console.WriteLine("[ 2 ] Kaikkien tuotteiden poisto");
            Console.WriteLine("[ 3 ] Valmis");
        }

        public void TuotteenValinta()
        {
            Console.Clear();
            Console.WriteLine("Valitse minkä tuotteen haluat poistaa.");
        }




        public void Poistu()
        {
            Console.WriteLine("Poistu painamalla enter");
        }

        public void TilauskenVahvistus()
        {
            Console.WriteLine("Tilaus lähetetty myyjälle tarkistettavaksi. Vahvistus ja lisätiedot tulevat sähköpostiin.");
            Console.WriteLine("Voit poistua painamalla enter");
        }

        // YHTEYSTIEDOT

        public void PystytMuokkaamaan()
        {
            Console.Clear();
            Console.WriteLine("Anna yhteystietosi. Pystyt muokkaamaan yhteystietoja tietojen antamisen jäkeen.\n");
        }
        public void YhteystietojenMuokkaus()
        {
            Console.WriteLine("\n\n[ 1 ] Muokkaa etunimeä.");
            Console.WriteLine("[ 2 ] Muokkaa sukunimeä.");
            Console.WriteLine("[ 3 ] Muokkaa puhelinnumeroa.");
            Console.WriteLine("[ 4 ] Muokkaa kotiosoitetta.");
            Console.WriteLine("[ 5 ] Muokkaa postinumeroa.");
            Console.WriteLine("[ 6 ] Muokkaa kaupunkia.");
            Console.WriteLine("[ 7 ] Muokkaa sähköpostia.");
            Console.WriteLine("[ 8 ] Jatka.");
        }

        public void Etunimi()
        {
            Console.WriteLine("Anna etunimesi, ole hyvä");
        }
        public void Sukunimi()
        {
            Console.WriteLine("Anna sukunimesi, ole hyvä");
        }
        public void Puhelinnumero()
        {
            Console.WriteLine("Anna puhelinnumerosi, ole hyvä");
        }
        public void Kotiosoite()
        {
            Console.WriteLine("Anna kotiosoitteesi, ole hyvä");
        }
        public void Postinumero()
        {
            Console.WriteLine("Anna postinumerosi, ole hyvä");
        }
        public void Kaupunki()
        {
            Console.WriteLine("Anna kaupunkisi, ole hyvä");
        }
        public void Sähköposti()
        {
            Console.WriteLine("Anna säköostiosoitteesi, ole hyvä");
        }

        // Myyjän sivu
        public void MyyjänValinnat()
        {
            Console.Clear();
            Console.WriteLine("Mitä haluat tehdä?");
            Console.WriteLine("[ 1 ] Tarkistele ja muokkaa tilauksia.");
            Console.WriteLine("[ 2 ] Tarkistele ja muokkaa Varastoa.");
            Console.WriteLine("[ 3 ] Poistu.");
        }
        public void TilausOtsikko1()
        {
            Console.WriteLine("Tilauksien tekijät:\n");
            Console.WriteLine("Tunniste\tNimi\tSukunimi\tPuhelin\t\tOsoite\t\t\t\tPostinumero\tKaupunki\tSähköposti");
        }
        public void TilausOtsikko2()
        {
            Console.WriteLine("\n\nTilatut tuotteet:");
            Console.WriteLine("\nTunniste\tTuotenumero\tNimi\t\t\t\tHinta\t\tKpl");
        }
        public void TilauksenKäsittely()
        {
            Console.WriteLine("\nMitä haluat tehdä?");
            Console.WriteLine("[ 1 ] Palaa alkuun.\n[ 2 ] Käsittele tilausta.");
        }
        public void TilauksenTunniste()
        {
            Console.WriteLine("Kirjoita tilauksen tunniste, jota haluat käsitellä");
        }
        public void TilausOtsikko()
        {
            Console.WriteLine("Tunniste\tTuotenumero\tNimi\t\t\t\tHinta\tKpl");
        }
        public void VähennettäväTuote()
        {
            Console.WriteLine("Anna tuotteen tunniste josta haluat vähentää");
        }
        public void LisättäväTuote()
        {
            Console.WriteLine("\nAnna tuotteen tunniste, jota haluat lisätä:");
        }
        public void Tallennus()
        {
            Console.WriteLine("Oletko varma että haluat tallentaa?\nKirjoita [ k ] jos haluat, ja [ e ] jos et halua");
        }
        public void Tallennettu()
        {
            Console.WriteLine("\nTallennettu");
            Console.WriteLine("Poistu painamalla enter");
        }
        public void Poistuit()
        {
            Console.WriteLine("\nPoistuit\n");
        }
    }
}
