

using System;
using System.Collections;
using System.Collections.Generic;

internal class Solver
{
    private string[] _input;
    private List<OrderRule> _ruleSet = new();
    private List<UpdateList> _updateLists = new();

    internal int SolvePartA()
    {
        this.ReadAndExtractInput();

        int returnValue = 0;
        foreach (var list in _updateLists)
        {
            returnValue += this.CalculateCorrectness(list);
        }

        return returnValue;
    }

    internal int SolvePartB()
    {
        int returnValue = 0;
        for (int i = 0; i < _updateLists.Count; i++)
        {
            if (!_updateLists[i].Correct)
            {
                returnValue += this.FixListOrder(_updateLists[i]);
            }
        }

        return returnValue;
    }

    private int FixListOrder(UpdateList list)
    {
        // check every number in list
        for (int i = 1; i < list.Items.Count; i++)
        {
            bool swapped = false;

            // look into every rule
            for (int j = 0; j < _ruleSet.Count; j++)
            {
                if (swapped)
                {
                    break;
                }

                // if a rule with rule.First for actual number (index i) exist
                if (list.Items[i] == _ruleSet[j].First)
                {
                    // check every number before the actual number (index i)
                    for (int k = 0; k < i; k++)
                    {
                        if (swapped)
                        {
                            break;
                        }

                        // to ensure that rule.Second is not before actual number (index i)
                        if (list.Items[k] == _ruleSet[j].Second)
                        {
                            // swap positions
                            (list.Items[i], list.Items[k]) = (list.Items[k], list.Items[i]);
                            swapped = true;

                            // start with comparing at actual set position
                            i = (k-1);
                        }
                    }
                }
            }

            // go here after swap
        }

        return list.Items[list.Items.Count / 2];
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
                            list.Correct = false;
                            return 0;
                        }
                    }
                }
            }
        }

        list.Correct = true;
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