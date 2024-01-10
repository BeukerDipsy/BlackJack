using BlackJack.Enums;

namespace BlackJack.Classes
{
    internal class Stapel
    {
        private List<Kaart> AlleKaarten = new List<Kaart>();
        private Random rnd = new Random();
        public List<Kaart> stapel = new List<Kaart>();

        public Stapel() 
        {
            KrijgKaarten();
            SchudKaarten();
            //HuidigeStapel();
        }

        //Maakt een nieuwe kaart aan (per symbool gaat hij kijken welke soort kaarten hij aan moet maken)
        private void KrijgKaarten()
        {
            AlleKaarten = new List<Kaart>();

            foreach (Symbool symbool in Enum.GetValues(typeof(Symbool)))
            {
                foreach (Waarde waarde in Enum.GetValues(typeof(Waarde)))
                {
                    AlleKaarten.Add(new Kaart(waarde, symbool));
                }
            }
        }

        //Pakt alle kaarten en voegt ze toe aan de stapel, gesorteerd in een random volgorde
        private void SchudKaarten() 
        {
            stapel = AlleKaarten.OrderBy(card => rnd.Next()).ToList();
        }

        //Schrijft de volgorde van de kaarten in de console zodat er te zien is of er wel of niet geschud is
        private void HuidigeStapel()
        {
            Console.WriteLine("-----Huidge Stapel-----");
            foreach (var kaart in stapel)
            {
                Console.WriteLine($"{kaart.KaartSymbool} {kaart.KaartWaarde}");
            }
            Console.WriteLine("-----------------------");
        }

        //Stelt de bovenstekaart samen en verwijderd deze van de stapel zodra deze opgeslagen is
        public Kaart PakVanStapel()
        {
            Kaart BovensteKaart = stapel[0];

            Symbool symbool = BovensteKaart.KaartSymbool;
            Waarde waarde = BovensteKaart.KaartWaarde;

            stapel.RemoveAt(0);
            return BovensteKaart;
            //Console.WriteLine(BovensteKaart.KaartSymbool + " " + BovensteKaart.KaartWaarde + "is druit");
            //HuidigeStapel();
        }
    }   
}
