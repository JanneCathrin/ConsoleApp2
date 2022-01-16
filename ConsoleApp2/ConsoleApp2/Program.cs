using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            var ord = GetWords();
            var ordTeller = 200;
            while (ordTeller > 0)
            {
                var HarFunnetmatch = FinnOrdProblem(ord);
                if (HarFunnetmatch) ordTeller--;

            }
        }

        private static bool FinnOrdProblem(string[] ord)
        {

            var TilfeldigOrdIndex = Random.Next(ord.Length);
            var ValgtOrd = ord[TilfeldigOrdIndex];
            Console.WriteLine(ValgtOrd + " - ");


            foreach (var O in ord)
            {

                if (!MatchDeTreSiste(ValgtOrd, O)) continue;
                Console.WriteLine(O);
                return true;
            }
                Console.WriteLine("Fant ikke en bra match");
                return false;
    
        }

        private static bool MatchDeTreSiste(string ord1, string ord2)
        {
            return MatchDeTreSiste(3, ord1, ord2)
            || MatchDeTreSiste(4, ord1, ord2)
            || MatchDeTreSiste(5, ord1, ord2);
        }

        private static bool MatchDeTreSiste(int commonLenght, string ord1, string ord2)
        {
            var SisteDelavFørsteOrd = ord1.Substring(ord1.Length - commonLenght, commonLenght);
            var FørsteDelavAndreOrd = ord2.Substring(0, commonLenght);

            return SisteDelavFørsteOrd == FørsteDelavAndreOrd;
        }


        static string[] GetWords()
        {
            var sisteOrd = string.Empty;
            var Fila = @"C:\Users\JaneC\source\repos\ConsoleApp2\ConsoleApp2\Ordliste.txt";
            var ordliste = new List<string>();
            foreach (var line in File.ReadLines(Fila, Encoding.UTF8))
            {
                var deler = line.Split('\t');
                var ord = deler[1];
                if (ord != sisteOrd
                    && ord.Length > 6
                    && ord.Length < 11
                    && !ord.Contains("-"))
             {
                    ordliste.Add(ord);
                }

                sisteOrd = ord;
          
            }

            return ordliste.ToArray();

        }


    }
}
