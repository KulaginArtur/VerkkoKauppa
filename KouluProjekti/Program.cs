using System;

namespace VerkkoKauppa
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++) // Ohjelma toistaa kysymisen 5 kertaa.
            {
                Console.WriteLine("Valitse tuote, jonka haluat lisätä ostoskoriin numerolla ennen tuotetta:");
                Console.WriteLine("1. Vanteet");
                Console.WriteLine("2. Vilkku Neste");
                var num = Console.ReadLine();
                int numero = int.Parse(num);

                /* 
                if (numero == 1)
                {
                    Console.WriteLine("Lisäsit tuotteen vanteet ostoskoriin.");
                }

                if (numero == 2)
                {
                    Console.WriteLine("Lisäsit tuotteen vilkku neste ostoskoriin.");
                }

                if (num == "e")
                {
                    break;
                }
                */
                switch (numero)
                {
                    case 1:
                        Console.WriteLine("Lisäsit tuotteen 1");
                        break;
                    case 2:
                        Console.WriteLine("Lisäsit tuotteen 2");
                        break;
                    case 9:
                        Console.WriteLine("Poistuit tuotelistasta.");
                        break;
                }
            }


        }
    }
}
