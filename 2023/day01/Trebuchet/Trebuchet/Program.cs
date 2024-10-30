namespace Trebuchet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToInputFile = @"C:\Users\user\source\repos\AoC\2023\day01\input.txt";
            int sum = 0;

            try
            {
                StreamReader reader = new StreamReader(pathToInputFile);
                string line = reader.ReadLine();

                while (line != null)
                {
                    sum += CalculateOneLine(line);
                    line = reader.ReadLine();
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(sum);
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
