using System;

namespace cse210_02
{
    public class Player
    {
        public int Score { get; set; } = 300;

        public string makeGuess()
        {
            Console.Write("Higher or lower (h/l)? ");
            string guess = Console.ReadLine();

            return guess;
        }

        public string playAgain()
        {
            Console.Write("Play Again (y/n)? ");
            string response = Console.ReadLine();

            return response;
        }
    }
}
