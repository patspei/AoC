
namespace HistorianHysteria
{
    internal class PartASolver
    {
        private StreamReader? reader;
        private int sum;
        private List<int> listA;
        private List<int> listB;

        public PartASolver(StreamReader reader)
        {
            this.reader = reader;
            this.sum = 0;
            this.listA = new List<int>();
            this.listB = new List<int>();
        }

        internal int Solve()
        {
            this.ReadInputFileAndCreateLists();
            this.SortListsAscending();
            this.CalculateDifferenzInAllLines();

            return this.sum;
        }

        private void CalculateDifferenzInAllLines()
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
                int difference = listA[i] - listB[i];
                if (difference < 0)
                {
                    difference *= -1;
                }

                this.sum += difference;
            }
        }

        private void SortListsAscending()
        {
            this.listA.Sort();
            this.listB.Sort();
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