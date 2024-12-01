using System.Text.RegularExpressions;

namespace GearRatios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"C:\Users\user\source\repos\AoC\2023\day03\input.txt";

            GearRatioA partA = new GearRatioA(pathToFile);
            int sumA = partA.CalculateSum();


            Console.WriteLine($"Sum A: {sumA}");

            Console.ReadKey();
        }
    }
}