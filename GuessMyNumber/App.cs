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
            string message = BisectList(3,list, list.Length / 2);
            Console.WriteLine(message);
            Console.WriteLine($"It took {_counter} iterations to complete the task.");
            _counter = 0;
        }

        private string BisectList(int numberToBeFound, int[] listForSearching, int pivotIndex)
        {
            _counter++;

            if (listForSearching == null)
            {
                return "VALUE NOT FOUND";
            }

            var middleOfList = listForSearching.Length / 2;
            var middleOfListNumber = listForSearching[middleOfList];

            if (middleOfListNumber == numberToBeFound)
            {
                return $"Your number is {middleOfListNumber}!";
            }
            if (middleOfListNumber > numberToBeFound)
            {
                Console.WriteLine($"{_counter}: {numberToBeFound} is less than {middleOfListNumber}");
                int range = listForSearching.GetUpperBound(0) - middleOfList;
                var newList = new int[range];
                for (int i = 0; i < range; i++)
                {
                    newList[i] = listForSearching[middleOfList + i];
                }
                return BisectList(numberToBeFound, newList);
            }
            if (middleOfListNumber < numberToBeFound)
            {
                Console.WriteLine($"{_counter}: {numberToBeFound} is greater than {middleOfListNumber}");
                int range = 0 + middleOfList;
                var newList = new int[range];
                for (int i = 0; i < range; i++)
                {
                    newList[i] = listForSearching[i];
                }
                return BisectList(numberToBeFound, newList);
            }

            return "VALUE NOT FOUND";
        }
    }
}