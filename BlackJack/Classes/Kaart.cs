using BlackJack.Enums;

namespace BlackJack
{
    internal class Kaart
    {
        public Waarde KaartWaarde { get; }
        public Symbool KaartSymbool { get; }

        public Kaart(Waarde kaartWaarde, Symbool kaartSymbool)
        {
            KaartWaarde = kaartWaarde;
            KaartSymbool = kaartSymbool;
        }

    }
}
