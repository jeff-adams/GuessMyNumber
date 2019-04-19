using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            new ImplementBisectionAlgorithm().Run();
            new HumanPlays().Run();
            new ComputerPlays().Run();

            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
