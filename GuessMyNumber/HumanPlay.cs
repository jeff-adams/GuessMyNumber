using System;
using System.Linq;

namespace GuessMyNumber
{
    class HumanPlays
    {
        private const int maxValue = 1000;

        private int counter;
        private int userGuess;
        private int computerNumber;
        private int[] numbers;

        public void Run()
        {
            StartingMessage();
            IntializeGuessingGame();
            GuessLoop();

            counter = 0;
        }

        private void StartingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"I am thinking of a number from 1 to {maxValue}");
            Console.WriteLine("I will tell you whether your guess is correct, too high, or too low");
            Console.WriteLine("Good luck!");
            Console.WriteLine();
        }

        private void IntializeGuessingGame()
        {
            numbers = Enumerable.Range(1,maxValue).ToArray();
            var rng = new Random();
            computerNumber = numbers[rng.Next(maxValue)];
        }

        private void GuessLoop()
        {
            counter++;
            AskForInput();

            if (userGuess == computerNumber)
            {
                Console.WriteLine();
                Console.WriteLine("You are correct!");
                Console.WriteLine($"It only took you {counter} guesses");
            }
            else if(userGuess > computerNumber)
            {
                Console.WriteLine($"{counter}: {userGuess} is too high");
                GuessLoop();
            }
            else if(userGuess < computerNumber)
            {
                Console.WriteLine($"{counter}: {userGuess} is too low");
                GuessLoop();
            }
        }

        private void AskForInput()
        {
            Console.Write("Enter a guess: ");
            userGuess = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            if (userGuess < 1 || userGuess > maxValue)
            {
                Console.WriteLine($"Please input a number between 1 and {maxValue}");
                AskForInput();
            }
        }
    }
}