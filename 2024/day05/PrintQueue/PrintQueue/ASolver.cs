internal class ASolver
{
    private string[] _input;
    private List<OrderRule> _ruleSet = new();
    private List<UpdateList> _updateLists = new();

    internal int Solve()
    {
        this.ReadAndExtractInput();

        int returnValue = 0;
        foreach (var list in _updateLists)
        {
            returnValue += this.CalculateCorrectness(list);
        }

        return returnValue;
    }

    private int CalculateCorrectness(UpdateList list)
    {
        for (int j = 0; j < list.Items.Count; j++)
        {
            int actual = list.Items[j];
            for (int i = 0; i < _ruleSet.Count; i++)
            {
                if (_ruleSet[i].Second == actual)
                {
                    // Check if First is in list after Second => not valid due to rule set
                    for (int k = (j + 1); k < list.Items.Count; k++)
                    {
                        if (list.Items[k] == _ruleSet[i].First)
                        {
                            return 0;
                        }
                    }
                }
            }
        }
        
        return list.Items[list.Items.Count / 2];
    }

    private void ReadAndExtractInput()
    {
        _input = File.ReadAllLines("../../../input.txt");

        for (int i = 0; i < _input.Length; i++)
        {
            if (_input[i].Contains('|'))
            {
                this.CreateRuleSet(i);
            }
            else if(_input[i].Contains(','))
            {
                this.CreateUpdateList(i);
            }
        }
    }

    private void CreateRuleSet(int i)
    {
        string[] ruleLine = _input[i].Split('|');

        _ruleSet.Add(new OrderRule()
        {
            First = int.Parse(ruleLine[0]),
            Second = int.Parse(ruleLine[1])
        });
    }

    private void CreateUpdateList(int i)
    {
        string[] updateLine = _input[i].Split(',');

        UpdateList updateList = new();
        foreach (string item in updateLine)
        {
            updateList.Items.Add(int.Parse(item));
        }

        _updateLists.Add(updateList);
    }
}