



string inputPath = @"C:\Users\user\source\repos\AoC\2024\day04\input.txt";
StreamReader reader = new StreamReader(inputPath);
string line = reader.ReadLine();

char[,] puzzleText = new char[140, 140];
int lineIndex = 0;

while (line != null)
{
    for (int rowIndex = 0; rowIndex < line.Length; rowIndex++)
    {
        puzzleText[lineIndex, rowIndex] = line[rowIndex];
    }

    line = reader.ReadLine();
    lineIndex++;
}

int sumA = 0;
for (lineIndex = 0; lineIndex < puzzleText.GetLength(1); lineIndex++)
{
    for (int rowIndex = 0; rowIndex < puzzleText.GetLength(0); rowIndex++)
    {
        if (puzzleText[lineIndex, rowIndex] == 'X')
        {
            sumA += CheckAllDirections(lineIndex, rowIndex);
        }
    }
}

reader.Close();
Console.WriteLine(sumA);

int CheckAllDirections(int lineIndex, int rowIndex)
{
    int positionSum = 0;
    positionSum += CheckUpLeft(lineIndex, rowIndex);
    positionSum += CheckUp(lineIndex, rowIndex);
    positionSum += CheckUpRight(lineIndex, rowIndex);
    positionSum += CheckRight(lineIndex, rowIndex);
    positionSum += CheckDownRight(lineIndex, rowIndex);
    positionSum += CheckDown(lineIndex, rowIndex);
    positionSum += CheckDownLeft(lineIndex, rowIndex);
    positionSum += CheckLeft(lineIndex, rowIndex);

    return positionSum;
}

int CheckUpLeft(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex - 1, rowIndex - 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex - 2, rowIndex - 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex - 3, rowIndex - 3, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckUp(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex - 1, rowIndex, 'M') &&
        CheckOnSpecifiedPosition(lineIndex - 2, rowIndex, 'A') &&
        CheckOnSpecifiedPosition(lineIndex - 3, rowIndex, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckUpRight(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex - 1, rowIndex + 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex - 2, rowIndex + 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex - 3, rowIndex + 3, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckRight(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex, rowIndex + 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex, rowIndex + 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex, rowIndex + 3, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckDownRight(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex + 1, rowIndex + 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex + 2, rowIndex + 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex + 3, rowIndex + 3, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckDown(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex + 1, rowIndex, 'M') &&
        CheckOnSpecifiedPosition(lineIndex + 2, rowIndex, 'A') &&
        CheckOnSpecifiedPosition(lineIndex + 3, rowIndex, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckDownLeft(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex + 1, rowIndex - 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex + 2, rowIndex - 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex + 3, rowIndex - 3, 'S'))
    {
        return 1;
    }

    return 0;
}

int CheckLeft(int lineIndex, int rowIndex)
{
    if (CheckOnSpecifiedPosition(lineIndex, rowIndex - 1, 'M') &&
        CheckOnSpecifiedPosition(lineIndex, rowIndex - 2, 'A') &&
        CheckOnSpecifiedPosition(lineIndex, rowIndex - 3, 'S'))
    {
        return 1;
    }

    return 0;
}

bool CheckOnSpecifiedPosition(int line, int row, char character)
{
    try
    {
        if (puzzleText[line, row] == character)
        {
            return true;
        }
    }
    catch (IndexOutOfRangeException)
    {
        return false;
    }

    return false;
}

Console.ReadKey();
