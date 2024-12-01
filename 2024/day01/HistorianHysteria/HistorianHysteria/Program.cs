namespace HistorianHysteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\user\source\repos\AoC\2024\day01\input.txt";
            int sumA = 0;
            int sumB = 0;

            try
            {
                StreamReader reader = new StreamReader(inputPath);
                PartASolver aSolver = new PartASolver(reader);
                sumA = aSolver.Solve();
                reader.Close();

                reader = new StreamReader(inputPath);
                PartBSolver bSolver = new PartBSolver(reader);
                sumB = bSolver.Solve();
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"Sum A: {sumA}");
            Console.WriteLine($"Sum B: {sumB}");

            Console.ReadKey();
        }
    }
}
