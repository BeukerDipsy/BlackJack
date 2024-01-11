using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using BlackJack.Enums;

namespace BlackJack.Classes
{
    internal class Game
    {
        private Stapel stapel;  
        private Speler speler;
        private Dealer dealer;
        private int dealerWins = 0;
        private int spelerWins = 0;
        private int startKaarten = 2;
        private int dealerWaarde = 0;
        private int spelerWaarde = 0;
        private int DealerMinimaal = 17;
        private bool spelerKapot = false;
        private bool dealerKapot = false;
        int maxTotKapot = 21;
        bool omgedraaideKaarten = true;
        private string meervoud = "";
        public Game() 
        {
            stapel = new Stapel();
            speler = new Speler(stapel);
            dealer = new Dealer(stapel);
            Welkom();
        }

        private void Begin()
        {
            ResetWaardes();
            int dealerExtraKaarten = 0;
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
            spelerWaarde = speler.DisplayStats();
            dealerWaarde = dealer.DisplayStats(omgedraaideKaarten);
            NogEenKaart();
            while (dealerWaarde < DealerMinimaal) 
            { 
                dealerExtraKaarten++;
                dealer.KrijgKaart();
                dealerWaarde = dealer.KrijgWaarde();
            }
            if (dealerExtraKaarten > 1 || dealerExtraKaarten == 0) 
            {
                meervoud = "en";
            }
            Console.WriteLine($"De dealer heeft {dealerExtraKaarten} kaart{meervoud} gepakt\n");
            omgedraaideKaarten = false;
            DisplayAllStats();
            if (spelerWaarde > maxTotKapot)
            {
                Console.WriteLine("Je bent kapot!");
                spelerKapot = true;
                if (dealerWaarde > maxTotKapot)
                {
                    Console.WriteLine("De Dealer is ook kapot");
                    dealerKapot = true;
                } 
            }
            else if (dealerWaarde > maxTotKapot)
            {
                Console.WriteLine("De dealer is kapot!");
                dealerKapot = true;
            }

            if (spelerKapot == true || dealerKapot == false && dealerWaarde > spelerWaarde)
            {
                Console.WriteLine("\nDe dealer heeft gewonnen!");
                dealerWins++;
            }
            else if (dealerKapot || spelerWaarde > dealerWaarde)
            { 
                Console.WriteLine("\nJe hebt gewonnen!");
                spelerWins++;
            }
            Console.WriteLine($"Speler-Dealer: [{spelerWins}]-[{dealerWins}] ");
            bool start = false;
            while (start == false)
            {
                Console.WriteLine("\n\n=======================================================================\n");
                Console.WriteLine("Wil je nog een potje spelen?");
                Console.WriteLine("\nYes [Y] No [N]");

                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    start = true;
                    Begin();
                    Console.WriteLine("\n\n=======================================================================\n");
                }
                else if (input == "N")
                {
                    Console.WriteLine("\n HOUDOE"); 
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze!");
                }
            }
        }

        private void Welkom()
        {
            bool start = false;
            while (start == false)
            {
                Console.WriteLine("Welkom bij blackjack!");
                Console.WriteLine("\nTyp [Y] om te beginnen en [R] om de regels te bekijken");

                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    start = true;
                    Console.WriteLine("=======================================================================\n");
                    Begin();
                }
                else if (input == "R")
                {
                    Console.WriteLine("\nRegels........"); //Ga ik niet toevoegen want is alleen maar wat lijntjes tekst
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze!");
                }
            }
        }
        private void NogEenKaart()
        {
            bool nogEenKaart = false;
            while (true)
            {
                Console.WriteLine("\nWil je nog een kaart [Y] of wil je dit aantal kaarten behouden [N]?");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.WriteLine("Je hebt ervoor gekozen een nieuwe kaart te krijgen\n");
                    Console.WriteLine("=======================================================================\n");
                    speler.KrijgKaart();
                    DisplayAllStats();
                    if (spelerWaarde <= maxTotKapot)
                    {
                        nogEenKaart = true;
                    }
                    else
                    {
                        nogEenKaart= false;
                    }
                    break;
                }
                else if (input == "N")
                {
                    Console.WriteLine("Je hebt ervoor gekozen geen nieuwe kaart te krijgen");
                    Console.WriteLine("=======================================================================");
                    break;
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze!");
                }
            }
            if (nogEenKaart)
            {
                NogEenKaart();
            }
        }

        private void DisplayAllStats()
        {
            spelerWaarde = speler.DisplayStats();
            dealer.DisplayStats(omgedraaideKaarten);
        }

        private void ResetWaardes()
        {
            speler.ClearHand();
            dealer.ClearHand();
            stapel.KrijgKaarten();
            dealerWaarde = 0;
            dealerKapot = false;
            spelerWaarde = 0;
            spelerKapot = false;
            omgedraaideKaarten = true;
            meervoud = "";
    }
    }
}
