using System;
using System.Linq;

namespace GuessMyNumber
{
    class ComputerPlays
    {
        private const int maxValue = 100;

        private int counter;
        private int guess;
        private int min;
        private int max;
        private int[] numbers;

        private bool isGuessing;

        public void Run()
        {
            StartingMessage();
            IntializeGuessingGame();
            GuessLoop();

            Console.WriteLine();
            Console.WriteLine($"Your number is {guess}!");
            Console.WriteLine($"It took {counter} iterations to find your number");

            counter = 0;
        }

        private void StartingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Think of a number from 1 to {maxValue}");
            Console.WriteLine("I will will try to guess your number");
            Console.WriteLine();
        }

        private void IntializeGuessingGame()
        {
            numbers = Enumerable.Range(1,maxValue).ToArray();
            isGuessing = true;
            min = 0;
            max = maxValue - 1;
        }

        private void GuessLoop()
        {
            while(isGuessing)
            {
                counter++;
                guess = numbers[(min + max) / 2];
                AskForInput();
            }
        }

        private void AskForInput()
        {
            Console.WriteLine($"{counter}: Is your number {guess}?");
            Console.WriteLine("Y: Yes | H: Too High | L: Too Low");
            var response = Console.ReadKey(true).Key;
            switch (response)
            {
                case ConsoleKey.Y:
                    isGuessing = false;
                    break;
                case ConsoleKey.H:
                    max = ((min + max) / 2) - 1;
                    break;
                case ConsoleKey.L:
                    min = ((min + max) / 2) + 1;
                    break;
                default:
                    AskForInput();
                    break;
            }
        }
    }
}