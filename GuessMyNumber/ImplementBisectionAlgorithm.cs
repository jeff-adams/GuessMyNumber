using System;
using System.Collections.Generic;

namespace GuessMyNumber
{
    class ImplementBisectionAlgorithm
    {
        private int counter = 0;
        private int numberToBeFound;

        public void Run()
        {
            var list = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            AskForInput();

            string message = BisectList(numberToBeFound,list, 0, list.Length - 1);
            Console.WriteLine(message);
            Console.WriteLine($"It took {counter} iterations to complete the task.");
            counter = 0;
        }

        private void AskForInput()
        {
            Console.Clear();
            Console.Write("Please enter a number from 1 - 10: ");
            numberToBeFound = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            if (numberToBeFound < 1 || numberToBeFound > 10)
            {
                AskForInput();
            }
        }

        private string BisectList(int numberToBeFound, int[] listForSearching, int min, int max)
        {
            counter++;

            if (min > max)
            {
                return "Number was not found";
            }

            var middleOfList = (min + max) / 2;
            var middleOfListNumber = listForSearching[middleOfList];

            if (middleOfListNumber == numberToBeFound)
            {
                return $"Your number is {middleOfListNumber}!";
            }
            else if (middleOfListNumber > numberToBeFound)
            {
                Console.WriteLine($"{counter}: {numberToBeFound} is less than {middleOfListNumber}");
                return BisectList(numberToBeFound, listForSearching, min, middleOfList - 1);
            }
            else
            {
                Console.WriteLine($"{counter}: {numberToBeFound} is greater than {middleOfListNumber}");
                return BisectList(numberToBeFound, listForSearching, middleOfList + 1, max);
            }
        }
    }
}