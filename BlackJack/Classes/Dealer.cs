using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    internal class Dealer
    {
        public List<Kaart> DealerHand = new List<Kaart>();
        private Stapel stapel;
        int MaxTotKapot = 21;

        //public Dealer(Stapel stapel, int maxToKapot)
        //{
        //    this.stapel = stapel;
        //    MaxTotKapot = maxToKapot;
        //}
        public Dealer(Stapel stapel)
        {
            this.stapel = stapel;
        }

        public void KrijgKaart()
        {
            DealerHand.Add(stapel.PakVanStapel());
            //foreach (Kaart kaart in DealerHand)
            //{
            //    Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde}");
            //}
        }

        public void DisplayKaarten()
        {
            Console.WriteLine("\n\nDealers hand:");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"{DealerHand[0].KaartSymbool} {DealerHand[0].KaartWaarde} ({(int)DealerHand[0].KaartWaarde})");
            for (int i = 0; i < DealerHand.Count -1; i++)
            {
                Console.WriteLine("Omgedraaide kaart");
            }
            Console.WriteLine("-----------------------");
        }

        private int HoeveelKaarten(int hoeveelkaarten)
        {
            foreach (Kaart kaart in DealerHand)
            {
                hoeveelkaarten++;
            }
            Console.WriteLine($"Je hebt momenteel {hoeveelkaarten} kaarten");
            return hoeveelkaarten;
        } 

        public int KrijgWaarde()
        {
            int HandWaarde = 0;
            foreach (Kaart kaart in DealerHand)
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
            foreach (Kaart kaart in DealerHand)
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
            Console.WriteLine($"De dealer heeft een totale waarde van {(int)DealerHand[0].KaartWaarde}+");
        }
    }
}
