

string inputPath = @"C:\Users\user\source\repos\AoC\2024\day03\input.txt";
StreamReader reader = new StreamReader(inputPath);

//int sumA = 0;
//string line = reader.ReadLine();

//while (line != null)
//{
//    sumA += CalculateOneLineRulesA(line);
//    line = reader.ReadLine();
//}

//Console.WriteLine($"Sum A: {sumA}");

int sumB = CalculateAllLinesRulesB(reader.ReadToEnd());
Console.WriteLine($"Sum B: {sumB}");

Console.ReadKey();

int CalculateAllLinesRulesB(string text)
{
    int sum = 0;
    bool executeMultiply = true;
    string[] lineParts = text.Split("do");

    sum += CalculateOneLineRulesA(lineParts[0]);

    for (int i = 1; i < lineParts.Length; i++)
    {
        if (lineParts[i].StartsWith("n't()"))
        {
            executeMultiply = false;
        }

        if (lineParts[i].StartsWith("()"))
        {
            executeMultiply = true;
        }

        if (executeMultiply)
        {
            sum += CalculateOneLineRulesA(lineParts[i]);
        }
    }
    
    return sum;
}

int CalculateOneLineRulesA(string line)
{
    int lineSum = 0;

    try
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != 'm')
            {
                continue;
            }

            if (line[i + 1] != 'u')
            {
                continue;
            }

            if (line[i + 2] != 'l')
            {
                continue;
            }

            if (line[i + 3] != '(')
            {
                continue;
            }

            int j = 1;
            string first = String.Empty;

            while (line[i + 3 + j] != ',' && j <= 3)
            {
                first += line[i + 3 + j];
                j++;
            }

            if (line[i + 3 + j] != ',')
            {
                continue;
            }

            int k = 1;
            string second = String.Empty;

            while (line[i + 3 + j + k] != ')' && k <= 3)
            {
                second += line[i + 3 + j + k];
                k++;
            }

            if (line[i + 3 + j + k] != ')')
            {
                continue;
            }

            if (int.TryParse(first, out int firstNumber) && int.TryParse(second, out int secondNumber))
            {
                lineSum += firstNumber * secondNumber;
                i += j + k;
            }
        }
    }
    catch (IndexOutOfRangeException)
    {
    }

    return lineSum;
}