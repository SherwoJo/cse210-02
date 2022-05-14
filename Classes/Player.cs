using System;

namespace cse210_02
{
    public class Player
    {
        private int score;
        public int Score
        { 
            get {return score;}
            set {score = 300;}
        }

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
