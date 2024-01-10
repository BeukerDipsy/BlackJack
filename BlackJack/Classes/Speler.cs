using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    internal class Speler
    {
        public List<Kaart> SpelerHand = new List<Kaart>();
        private Stapel stapel;
        int MaxTotKapot = 21;

        public Speler(Stapel stapel)
        {
            this.stapel = stapel;
        }

        public void KrijgKaart()
        {
            SpelerHand.Add(stapel.PakVanStapel());
            //foreach (Kaart kaart in SpelerHand)
            //{
            //    Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde}");
            //}
        }

        public void DisplayKaarten()
        {
            int hoeveelKaarten = 0;
            //hoeveelKaarten = HoeveelKaarten(hoeveelKaarten);
            Console.WriteLine($"Jouw hand:\n-----------------------");
            foreach (Kaart kaart in SpelerHand)
            {
                if ((int)kaart.KaartWaarde < 11)
                {
                    Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} ({(int)kaart.KaartWaarde})");
                }
                else if  ((int)kaart.KaartWaarde == 11)
                {
                    Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} (1/11)");
                }
                else if ((int)kaart.KaartWaarde > 11)
                {
                    Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} (10)");
                }
            }
            Console.WriteLine("-----------------------");
        }

        public int KrijgWaarde()
        {
            int HandWaarde = 0;
            foreach (Kaart kaart in SpelerHand)
            {
                if ((int)kaart.KaartWaarde > 11)
                {
                     HandWaarde += 10;
                }
                else
                {
                    HandWaarde += (int)kaart.KaartWaarde;
                }
            }
            if (HandWaarde > MaxTotKapot)
            {
                HandWaarde = AasCheck(HandWaarde);
            }
            return HandWaarde;
        }

        private int AasCheck(int HandWaarde)
        {
            foreach (Kaart kaart in SpelerHand)
            {
                if ((int)kaart.KaartWaarde == 11)
                {
                    HandWaarde = HandWaarde - 10;
                }
                if (HandWaarde <= MaxTotKapot)
                {
                    return HandWaarde;
                }
            }
            return HandWaarde;
        }

        public void DisplayWaarde(int HandWaarde)
        {
            Console.WriteLine($"Je kaarten hebben een totale waarde van {HandWaarde}");
        }

        private int HoeveelKaarten(int hoeveelkaarten)
        {
            foreach (Kaart kaart in SpelerHand)
            {
                hoeveelkaarten++;
            }
            Console.WriteLine($"Je hebt momenteel { hoeveelkaarten} kaarten");
            return hoeveelkaarten;
        }
    }
}
