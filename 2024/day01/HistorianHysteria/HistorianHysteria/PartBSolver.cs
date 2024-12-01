
namespace HistorianHysteria
{
    internal class PartBSolver
    {
        private StreamReader? reader;
        private int sum;
        private List<int> listA;
        private List<int> listB;

        public PartBSolver(StreamReader reader)
        {
            this.reader = reader;
            this.sum = 0;
            this.listA = new List<int>();
            this.listB = new List<int>();
        }

        internal int Solve()
        {
            this.ReadInputFileAndCreateLists();
            this.CalculateSimilarityIndexForAllLines();

            return this.sum;
        }

        private void CalculateSimilarityIndexForAllLines()
        {
            if (this.listA == null)
            {
                throw new ArgumentNullException(nameof(this.listA));
            }

            if (this.listB == null)
            {
                throw new ArgumentNullException(nameof(this.listB));
            }

            for (int i = 0; i < this.listA.Count; i++)
            {
                int count = 0;

                for (int j = 0; j < this.listB.Count; j++)
                {
                    if (this.listA[i] == this.listB[j])
                    {
                        count++;
                    }
                }

                this.sum += this.listA[i] * count;
            }
        }

        private void ReadInputFileAndCreateLists()
        {
            if (this.reader == null)
            {
                throw new ArgumentNullException(nameof(this.reader));
            }

            try
            {
                string? line = this.reader.ReadLine();

                while (line != null)
                {
                    string[] lineParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    this.listA.Add(this.ParseToInt(lineParts[0]));
                    this.listB.Add(this.ParseToInt(lineParts[1]));
                    line = this.reader.ReadLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Datei nicht gefunden.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Zugriff verweigert.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {e.Message}");
            }
        }

        private int ParseToInt(string input)
        {
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                throw new ArgumentException("input not parseable");
            }
        }
    }
}