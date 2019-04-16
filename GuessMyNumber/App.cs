using System;
using System.Collections.Generic;

namespace GuessMyNumber
{
    class App
    {
        private int _counter = 0;

        public void Run()
        {
            var list = new int[]{1, 2, 3, 4, 5, 6, 7, 8 , 9, 10};
            string message = BisectList(3,list);
            Console.WriteLine(message);
            Console.WriteLine($"It took {_counter} iterations to complete the task.");
            _counter = 0;
        }

        private string BisectList(int number, int[] list)
        {
            _counter++;

            if (list == null)
            {
                return "VALUE NOT FOUND";
            }

            var middleOfList = list.Length / 2;
            var middleOfListValue = list[middleOfList];

            if (middleOfListValue == number)
            {
                return $"Your number is {middleOfListValue}!";
            }
            if (middleOfListValue > number)
            {
                Console.WriteLine($"{_counter}: {number} is less than {middleOfListValue}");
                int range = list.GetUpperBound(0) - list[middleOfList];
                var newList = new int[range];
                for (int i = 0; i < range; i++)
                {
                    newList[i] = list[middleOfList + i];
                }
                return BisectList(number, newList);
            }
            if (middleOfListValue < number)
            {
                Console.WriteLine($"{_counter}: {number} is greater than {middleOfListValue}");
            }
        }
    }
}