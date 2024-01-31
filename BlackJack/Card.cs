namespace BlackJack {
    public class Card {
        private CardSuit Suit;
        public int Value {  get; private set; }

        public Card(CardSuit suit, int value) {
            this.Suit = suit;
            this.Value = value >= 10 ? 10 : value;
        }

        private string ValueToString() {
            switch (Value) {
                case 1: return "A";
                case 10: return "J";
                case 11: return "Q";
                case 12: return "K";
                default: return Value.ToString();
            }
        }

        public string GetSuitIcon(){
            switch (Suit) {
                case CardSuit.Diamonds: return "\u2666";//♦
                case CardSuit.Hearts: return "\u2665";  //♥
                case CardSuit.Spades: return "\u2660";  //♠
                case CardSuit.Clubs: return "\u2663";   //♣
                default: return "";
            }
        }

        public override string ToString() {
            string valueStr = ValueToString();
            string cardString = $"+-------+\n|{valueStr}      |\n|       |\n|   {GetSuitIcon()}   |\n|       |\n|      {valueStr}|\n+-------+";
            return cardString;
            //Example

            //+-------+
            //|J      |
            //|       |
            //|   ♥   |
            //|       |
            //|      J|
            //+-------+
        }
    }
}