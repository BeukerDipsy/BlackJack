using System.Numerics;
using System.Reflection;
using BlackJack.Enums;

namespace BlackJack.Classes
{
    internal class Game
    {
        private Stapel stapel;  
        private Speler speler;
        private Dealer dealer;
        private int startKaarten = 2;
        private int DealerWaarde = 0;
        private int SpelerWaarde = 0;
        public Game() 
        {
            stapel = new Stapel();
            speler = new Speler(stapel);
            dealer = new Dealer(stapel);
            Begin();
        }

        private void Begin()
        {
            Welkom();
            //Geef dealer 2 kaarten
            for (int i = 0; i < startKaarten; i++)
            {
                dealer.KrijgKaart();
            }
            //Geef speler 2 kaarten
            for (int i = 0; i < startKaarten; i++) 
            {
                speler.KrijgKaart();
            }
            speler.DisplayKaarten();
            SpelerWaarde = speler.KrijgWaarde();
            speler.DisplayWaarde(SpelerWaarde);

            dealer.DisplayKaarten();
            DealerWaarde = dealer.KrijgWaarde();
            dealer.DisplayWaarde(DealerWaarde);

        }


        private void Welkom()
        {
            bool start = false;
            while (start == false)
            {
                Console.WriteLine("Welkom bij blackjack!");
                Console.WriteLine("\nTyp [Y] om te beginnen en [N] om ");

                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    start = true;
                    Console.WriteLine("=======================================================================\n");
                }
                else if (input == "N")
                {
                    Console.WriteLine("\nHOUDOE!");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Ongeldige keuze!");
                }
            }
        }
    }
}
