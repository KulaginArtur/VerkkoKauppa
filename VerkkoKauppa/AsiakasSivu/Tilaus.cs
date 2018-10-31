using System;
using System.Collections.Generic;
using System.Linq;

namespace VerkkoKauppa
{
    public class Tilaus
    {
        // Tuotteiden haku ja tallennus
        public List<Tilausrivi> tilausrivit = new List<Tilausrivi>();

        public Tilaus()
        {
        }
    }
}

    public class Tilausrivi 
    {
        
        public string Tuotenimi { get; set; }
        public int Tuotenumero { get; set; }
        public double Hinta { get; set; }
        public int Kpl { get; set; }

        public Tilausrivi()
        {
        }
}

