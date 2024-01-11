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

        public void DisplayKaarten(bool omgedraaideKaarten)
        {
            Console.WriteLine("\n\nDealers hand:");
            Console.WriteLine("-----------------------");
            if (omgedraaideKaarten)
            {
                if ((int)DealerHand[0].KaartWaarde > 11)
                {
                    Console.WriteLine($"{DealerHand[0].KaartSymbool} {DealerHand[0].KaartWaarde} (10)");
                }
                else if ((int)DealerHand[0].KaartWaarde == 11)
                {
                    Console.WriteLine($"{DealerHand[0].KaartSymbool} {DealerHand[0].KaartWaarde} (1/11)");
                }
                else
                {
                    Console.WriteLine($"{DealerHand[0].KaartSymbool} {DealerHand[0].KaartWaarde} ({(int)DealerHand[0].KaartWaarde})");
                }
                for (int i = 0; i < DealerHand.Count - 1; i++)
                {
                    Console.WriteLine("Omgedraaide kaart");
                }
            }
            else
            {
                foreach (Kaart kaart in DealerHand)
                {
                    if ((int)kaart.KaartWaarde < 11)
                    {
                        Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} ({(int)kaart.KaartWaarde})");
                    }
                    else if ((int)kaart.KaartWaarde == 11)
                    {
                        Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} (1/11)");
                    }
                    else if ((int)kaart.KaartWaarde > 11)
                    {
                        Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde} (10)");
                    }
                }
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
        public void DisplayWaarde(int HandWaarde, bool omgedraaideKaarten)
        {
            if  (omgedraaideKaarten)
            {
                if ((int)DealerHand[0].KaartWaarde > 11)
                {
                    Console.WriteLine($"De dealer heeft een totale waarde van 10+");
                }
                else
                {
                    Console.WriteLine($"De dealer heeft een totale waarde van {(int)DealerHand[0].KaartWaarde}+");
                }
            }
            else
            {
                Console.WriteLine($"De dealer heeft een totale waarde van {HandWaarde}");
            }
        }

        public int DisplayStats(bool omgedraaideKaarten)
        {
            DisplayKaarten(omgedraaideKaarten);
            int Waarde = 0;
            Waarde = KrijgWaarde();
            DisplayWaarde(Waarde, omgedraaideKaarten);
            return Waarde;
        }

        public void ClearHand()
        {
            DealerHand.Clear();
        }
    }
}
