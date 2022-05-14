using System;

namespace cse210_02
{
    class Program
    {
        static void Main(string[] args)
        {
            displayRules();

            // Start the first turn.
            bool gameOver = false;
            Console.Write("Would you like to see the first card (y/n)? ");
            string response = Console.ReadLine();
            Console.WriteLine("");

            // See if the player wants to play.
            gameOver = detectGameOver(response);

            // Create the game objects
            Player Player = new Player();
            Deck Deck = new Deck();

            // Start the main gameplay loop.
            while (!gameOver)
            {
                // Draw a new card and display it to the user.
                int firstCard = Deck.drawCard();
                Console.WriteLine($"The first card is: {firstCard}");

                // Have the player guess higher or lower.
                string guess = Player.makeGuess();

                // Draw the next card and display it to the user.
                int nextCard = Deck.drawCard();
                Console.WriteLine($"Next card was: {nextCard}");

                // Check if the player's guess was correct and award points.
                int pointsAwarded = awardPoints(firstCard, nextCard, guess);

                // Update and display the player's score.
                Player.Score += pointsAwarded;
                Console.WriteLine($"Your new score is: {Player.Score}");

                // End the game if the player's score is 0.
                if (Player.Score < 1)
                {
                    Console.WriteLine("Game over, your points have reached 0.");
                    gameOver = true;
                }
                // Ask the player if they want to play again.
                else
                {
                    response = Player.playAgain();
                    gameOver = detectGameOver(response);
                }
                
                // Print a blank line.
                Console.WriteLine("");                
            }

            Console.WriteLine("Thanks for playing!");
        }

        static void displayRules()
        {
            // Explain the rules of the game.
            Console.WriteLine("Welcome to Hilo!");
            Console.WriteLine("In this game, each turn you will be shown the value of a card");
            Console.WriteLine("and you will have to guess if the next card will be higher or lower.");

            Console.WriteLine("\nYou start the game with 300 points.");
            Console.WriteLine("If you guess correctly, you gain points.");
            Console.WriteLine("If you guess incorrectly, you will lose points.");
        }

        static bool detectGameOver(string response)
        {
            bool gameOver = false;

            if (response == "n")
            {
                gameOver = true;
            }

            return gameOver;
        }

        static int awardPoints(int firstCard, int nextCard, string guess)
        {
            int pointsAwarded = 0;

            if(nextCard > firstCard && guess == "h" || nextCard < firstCard && guess == "l")
            {
                pointsAwarded = 100;
            }
            else if(nextCard > firstCard && guess == "l" || nextCard < firstCard && guess == "h")
            {
                pointsAwarded = -75;
            }

            return pointsAwarded;
        }
    }
}
