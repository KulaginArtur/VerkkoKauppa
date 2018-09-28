using System;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            MinunLuokka.Nimi = "Oma luokka";
            Console.WriteLine(MinunLuokka.TulostaNimi());
        }
    }
    static class MinunLuokka
    {
        public static string Nimi;
        public static string TulostaNimi()
        {
            return Nimi;
        }
    }
}
