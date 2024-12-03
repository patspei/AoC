
string inputPath = @"C:\Users\user\source\repos\AoC\2024\day02\input.txt";

StreamReader reader = new StreamReader(inputPath);
string line = reader.ReadLine();
int sumA = 0;
int sumB = 0;

while (line != null)
{
    int[] lineAsNumbers = ParseToIntArray(line);
    if (CheckLineForRulesPartA(lineAsNumbers))
    {
        sumA++;
        sumB++;
    }
    else if (CheckLineForRulesPartB(lineAsNumbers))
    {
        sumB++;
    }

    line = reader.ReadLine();
}

reader.Close();
Console.WriteLine($"SumA: {sumA}");
Console.WriteLine($"SumB: {sumB}");
Console.ReadKey();

int[] ParseToIntArray(string line)
{
    string[] lineAsStringArray = line.Split(' ');
    int[] lineAsIntArray = new int[lineAsStringArray.Length];

    for (int i = 0; i < lineAsStringArray.Length; i++)
    {
        lineAsIntArray[i] = int.Parse(lineAsStringArray[i]);
    }

    return lineAsIntArray;
}

bool CheckLineForRulesPartA(int[] line)
{
    int actual = line[0];
    int next = line[1];

    bool increasing = false;
    if (actual < next)
    {
        increasing = true;
    }
    else if (actual == next)
    {
        return false;
    }

    if (Math.Abs(actual - next) > 3)
    {
        return false;
    }

    for (int i = 2; i < line.Length; i++)
    {
        actual = next;
        next = line[i];

        if (actual == next)
        {
            return false;
        }

        if (increasing && actual > next)
        {
            return false;
        }

        if (!increasing && actual < next)
        {
            return false;
        }

        if (Math.Abs(actual - next) > 3)
        {
            return false;
        }
    }

    return true;
}

bool CheckLineForRulesPartB(int[] line)
{
    int[] lineOneNumberLess = new int[line.Length - 1];

    for (int i = 0; i < line.Length; i++)
    {
        int index = 0;

        for (int j = 0; j < line.Length; j++)
        {
            if (i == j)
            {
                continue;
            }

            lineOneNumberLess[index] = line[j];
            index++;
        }

        if (CheckLineForRulesPartA(lineOneNumberLess))
        {
            return true;
        }
    }

    return false;
}