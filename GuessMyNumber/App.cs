using System;
using System.Collections.Generic;

namespace GuessMyNumber
{
    class App
    {
        private int _counter = 0;

        public void Run()
        {
            var list = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            string message = BisectList(3,list, 0, list.Length - 1);
            Console.WriteLine(message);
            Console.WriteLine($"It took {_counter} iterations to complete the task.");
            _counter = 0;
        }

        private string BisectList(int numberToBeFound, int[] listForSearching, int min, int max)
        {
            _counter++;

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
                Console.WriteLine($"{_counter}: {numberToBeFound} is less than {middleOfListNumber}");
                return BisectList(numberToBeFound, listForSearching, min, middleOfList - 1);
            }
            else
            {
                Console.WriteLine($"{_counter}: {numberToBeFound} is greater than {middleOfListNumber}");
                return BisectList(numberToBeFound, listForSearching, middleOfList + 1, max);
            }
        }
    }
}