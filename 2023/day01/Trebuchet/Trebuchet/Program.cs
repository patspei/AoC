namespace Trebuchet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToInputFile = @"C:\Users\user\source\repos\AoC\2023\day01\input.txt";
            int sumA = 0;
            int sumB = 0;

            try
            {
                StreamReader reader = new StreamReader(pathToInputFile);
                string line = reader.ReadLine();

                while (line != null)
                {
                    string changedLine = TranslateToNumbers(line);
                    sumA += CalculateOneLine(line);
                    sumB += CalculateOneLine(changedLine);
                    line = reader.ReadLine();
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"A: {sumA}");
            Console.WriteLine($"B: {sumB}");
            Console.ReadKey();
        }

        private static string TranslateToNumbers(string line)
        {
            string newLine = line.Replace("one", "one1one");
            newLine = newLine.Replace("two", "two2two");
            newLine = newLine.Replace("three", "three3three");
            newLine = newLine.Replace("four", "four4four");
            newLine = newLine.Replace("five", "five5five");
            newLine = newLine.Replace("six", "six6six");
            newLine = newLine.Replace("seven", "seven7seven");
            newLine = newLine.Replace("eight", "eight8eight");
            newLine = newLine.Replace("nine", "nine9nine");

            return newLine;
        }

        private static int CalculateOneLine(string line)
        {
            int first = 0;
            int tempLast = 0;
            int last = 0;

            for (int i = 0; i < line.Length; i++)
            {
                bool parseAble = int.TryParse(line[i].ToString(), out first);

                if (parseAble)
                {
                    break;
                }
            }

            for (int i = 0; i < line.Length; i++)
            {
                bool parseable = int.TryParse(line[i].ToString(), out tempLast);

                if (parseable)
                {
                    last = tempLast;
                }
            }

            return first * 10 + last;
        }
    }
}
