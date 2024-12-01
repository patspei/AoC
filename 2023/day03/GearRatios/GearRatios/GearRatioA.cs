
using System.Text.RegularExpressions;

namespace GearRatios
{
    internal class GearRatioA
    {
        private string prevLineOriginal;
        private string prevLineRemovedNumbers;
        private string actualLine;
        private string? nextLineOriginal;
        private string nextLineRemovedNumbers;
        private int sum = 0;
        private StreamReader reader;

        public GearRatioA(string pathToFile)
        {
            this.reader = new StreamReader(pathToFile);
        }

        internal int CalculateSum()
        {
            try
            {
                this.actualLine = this.reader.ReadLine();
                this.prevLineRemovedNumbers = new string('.', this.actualLine.Length);
                this.nextLineOriginal = this.reader.ReadLine();
                this.nextLineRemovedNumbers = this.ReplaceNumbersWithPoint(this.nextLineOriginal);

                while (this.nextLineOriginal != null)
                {
                    this.CheckLineAndAddToSum();
                    Console.WriteLine(this.sum);
                    this.RebuildLines();
                }

                this.Checklastline();
                Console.WriteLine(this.sum);
                this.reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this.sum;
        }

        private void Checklastline()
        {
            this.nextLineRemovedNumbers = new string('.', this.actualLine.Length);
            this.CheckLineAndAddToSum();
        }

        private void RebuildLines()
        {
            this.prevLineRemovedNumbers = this.ReplaceNumbersWithPoint(this.actualLine);
            this.actualLine = this.nextLineOriginal;
            this.nextLineOriginal = this.reader.ReadLine();
            if (this.nextLineOriginal == null)
            {
                return;
            }

            this.nextLineRemovedNumbers = this.ReplaceNumbersWithPoint(this.nextLineOriginal);
        }

        private void CheckLineAndAddToSum()
        {
            for (int i = 0; i < this.actualLine.Length; i++)
            {
                if (int.TryParse(this.actualLine[i].ToString(), out int firstDigit))
                {
                    int number = firstDigit;
                    int digits = 1;

                    if (i + 1 < this.actualLine.Length && int.TryParse(this.actualLine[i + 1].ToString(), out int secondDigit))
                    {
                        number = number * 10 + secondDigit;
                        digits++;

                        if (i + 2 < this.actualLine.Length && int.TryParse(this.actualLine[i + 2].ToString(), out int thirdDigit))
                        {
                            number = number * 10 + thirdDigit;
                            digits++;
                        }
                    }

                    if (this.CheckIfNumberAdjanceSymbol(i, digits))
                    {
                        this.sum += number;
                    }

                    i += digits;
                }
            }
        }

        private bool CheckIfNumberAdjanceSymbol(int i, int digits)
        {
            // prev .....  or ....  or ...
            // actu .123.     .12.     .1.
            // next .....     ....     ...

            if (digits >= 4)
            {
                throw new ArgumentException($"Digits is : {digits}");
            }

            // prev .X...  or .X..  or .X.
            // actu .123.     .12.     .1.
            // next .X...     .X..     .X.
            if (this.prevLineRemovedNumbers[i] != '.' || this.nextLineRemovedNumbers[i] != '.')
            {
                return true;
            }

            // prev Xx...  or Xx..  or Xx.
            // actu X123.     X12.     X1.
            // next Xx...     Xx..     Xx.
            if (i > 0)
            {
                if (this.prevLineRemovedNumbers[i - 1] != '.' || this.actualLine[i - 1] != '.' || this.nextLineRemovedNumbers[i - 1] != '.')
                {
                    return true;
                }
            }

            // prev xxX..  or xxX.  or xxX
            // actu x123.     x12.     x1X
            // next xxX..     xxX.     xxX
            if (i < this.actualLine.Length - 1) // means i < 139
            {
                if (this.prevLineRemovedNumbers[i + 1] != '.' || this.nextLineRemovedNumbers[i + 1] != '.')
                {
                    return true;
                }

                if (digits == 1 && this.actualLine[i + 1] != '.')
                {
                    return true;
                }
            }

            // prev xxxX.  or xxxX  or xxx
            // actu x123.     x12X     x1x
            // next xxxX.     xxxX     xxx
            if (i < this.actualLine.Length - 2) // means i < 138
            {
                if (this.prevLineRemovedNumbers[i + 2] != '.' || this.nextLineRemovedNumbers[i + 2] != '.')
                {
                    return true;
                }

                if (digits == 2 && this.actualLine[i + 2] != '.')
                {
                    return true;
                }
            }

            // prev xxxxX  or xxxx  or xxx
            // actu x123X     x12x     x1x
            // next xxxxX     xxxx     xxx
            if (i < this.actualLine.Length - 3) // means i < 137
            {
                if (this.prevLineRemovedNumbers[i + 3] != '.' || this.actualLine[i + 3] != '.' || this.nextLineRemovedNumbers[i + 3] != '.')
                {
                    return true;
                }
            }

            return false;
        }

        private string ReplaceNumbersWithPoint(string originalString)
        {
            return Regex.Replace(originalString, "[0123456789]", ".");
        }
    }
}