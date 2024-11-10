namespace CubeConundrum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToInputFile = @"C:\Users\user\source\repos\AoC\2023\day02\input.txt";
            int sum = 0;
            int power = 0;

            try
            {
                StreamReader stream = new StreamReader(pathToInputFile);
                string line = stream.ReadLine();

                while (line != null)
                {
                    sum += CheckLineIfLegitGame(line);
                    power += CalculatePowerOfGame(line);
                    line = stream.ReadLine();
                }

                Console.WriteLine(sum);
                Console.WriteLine(power);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static int CalculatePowerOfGame(string line)
        {
            int redHigh = 0;
            int greenHigh = 0;
            int blueHigh = 0;

            string[] game = line.Split(':');
            string[] picks = game[1].Split(',', ';');

            foreach (var pick in picks)
            {
                string[] oneNumberAndColor = pick.Trim().Split(' ');
                int number = Int32.Parse(oneNumberAndColor[0]);
                string color = oneNumberAndColor[1];

                switch (color)
                {
                    case "red":
                        if (number > redHigh)
                        {
                            redHigh = number;
                        }
                        break;

                    case "green":
                        if (number > greenHigh)
                        {
                            greenHigh = number;
                        }
                        break;

                    case "blue":
                        if (number > blueHigh)
                        {
                            blueHigh = number;
                        }
                        break;

                    default:
                        break;
                }
            }

            return redHigh * greenHigh * blueHigh;
        }

        private static int CheckLineIfLegitGame(string line)
        {
            int redMax = 12;
            int greenMax = 13;
            int blueMax = 14;

            string[] game = line.Split(':');
            int gameNumber = Int32.Parse(game[0].Replace("Game ", String.Empty));

            string[] picks = game[1].Split(',', ';');

            foreach (var pick in picks)
            {
                string[] oneNumberAndColor = pick.Trim().Split(' ');
                int number = Int32.Parse(oneNumberAndColor[0]);
                string color = oneNumberAndColor[1];

                switch (color)
                {
                    case "red":
                        if (number > redMax)
                        {
                            return 0;
                        }
                        break;

                    case "green":
                        if (number > greenMax)
                        {
                            return 0;
                        }
                        break;

                    case "blue":
                        if (number > blueMax)
                        {
                            return 0;
                        }
                        break;

                    default:
                        break;
                }
            }

            return gameNumber;
        }
    }
}
