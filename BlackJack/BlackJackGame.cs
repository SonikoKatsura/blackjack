namespace BlackJack {
    public class BlackJackGame {
        private static Deck Deck = new();
        private static Croupier Croupier = new();
        private static BlackJackPlayer Player;

        public static void Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For the card symbols to work
            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("Enter your name");
            Player = new BlackJackPlayer(Console.ReadLine() ?? "");

            InitializeGame();

            bool hasFinished = false;
            while (!hasFinished) {
                Console.WriteLine($"You are now at : {Player.Score}");
                if (Player.Score == 21) break;

                string answer = AskForAnotherCard();

                if (answer == "n") hasFinished = true;
                else {
                    Console.Clear();
                    Player.Draw(Deck);
                    PrintCards();
                }
                Player.CalculateScore();
                if (Player.IsBust() || Player.Score == 21) hasFinished = true;
            }
            
            Croupier.Draw(Deck);
            Console.WriteLine();
            CheckResult();
        }

        public static void InitializeGame() {
            Console.Clear();
            Deck.Shuffle();
            Croupier.Draw(Deck);
            Croupier.Draw(Deck);
            Croupier.CalculateScore();
            Player.Draw(Deck);
            Player.Draw(Deck);
            Player.CalculateScore();
            PrintCards();
        }

        public static void PrintCards(int num = 1) {
            Croupier.Print(num);
            Console.WriteLine();
            Player.Print();
            Console.WriteLine();
        }

        public static string AskForAnotherCard() {
            Console.WriteLine("Do you want to draw another card? (y/n)");
            string answer = string.Empty;
            while (answer != "y" && answer != "n"){
                answer = Console.ReadLine() ?? "".ToLower();
                if (answer != "y" && answer != "n") Console.WriteLine("Please enter y or n");
            }
            return answer;
        }

        public static void CheckResult() {
            Console.Clear();
            PrintCards(0);
            Console.WriteLine($"Croupier Score: {Croupier.Score}");
            Console.WriteLine($"{Player.Name} Score: {Player.Score}");
            if (Player.IsBust()) Console.WriteLine("You are bust!");
            if (Croupier.IsBust()) Console.WriteLine("Croupier is bust!");

            if (Player.IsBust() && Croupier.IsBust()) Console.WriteLine("Draw!");
            else if (!Player.IsBust() && Croupier.IsBust()) Console.WriteLine("You win!");
            else if (Player.IsBust() && !Croupier.IsBust()) Console.WriteLine("You lose!");
            else
                if (Croupier.Score < Player.Score) Console.WriteLine("You win!");
                else if (Player.Score < Croupier.Score) Console.WriteLine("You lose!");
                else {
                    if (Croupier.GetNumberOfCards() < Player.GetNumberOfCards()) Console.WriteLine("You lose! Croupier won thanks to dealer's advantage!");
                    else Console.WriteLine("Draw!");
                }
        }
    }
}