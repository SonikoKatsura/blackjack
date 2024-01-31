namespace BlackJack {
    public class Deck {
        private List<Card> Cards;

        public Deck() {
            Cards = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                for (int i = 1; i < 13; i++) Cards.Add(new Card(suit, i));
        }

        public void Shuffle() {
            Random random = new Random();
            Cards = Cards.OrderBy(x => random.Next()).ToList();
        }

        public Card Draw() {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public void Print() {
            foreach (Card card in Cards) Console.WriteLine(card.ToString());
        }
    }
}