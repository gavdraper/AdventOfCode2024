using System.Globalization;
using AocBase;
using Microsoft.VisualBasic;

var day = new Day11("55312", "", "224529", "");
day.Solve(true);

public class Day11 : Day
{
    public Day11(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
        string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult,
        expectedResultTwo)
    {
    }

    readonly LinkedList<long> _stones = new LinkedList<long>();

    private void Setup()
    {
        _stones.Clear();
        foreach (var n in Input.Split(" ").Select(x => long.Parse(x))) _stones.AddLast(n);
    }

    protected override string ProcessPartOne()
    {
        Setup();
        return SolveIt(25);
    }

    protected override string ProcessPartTwo()
    {
        Setup();
        return SolveIt(75);
    }

    private string SolveIt(int blinkCount)
    {
        for (var blink = blinkCount; blinkCount > 0; blinkCount--)
        {
            Console.WriteLine(blinkCount + " : " + _stones.Count);
            LinkedListNode<long> currentNode = _stones.First;
            while (currentNode != null)
            {
                if (currentNode.Value == 0)
                {
                    currentNode.Value = 1;
                    currentNode = currentNode.Next;
                }
                else if (currentNode.Value.ToString().Length % 2 == 0)
                {
                    var engraving = currentNode.Value.ToString();
                    var firstStone = long.Parse(engraving.Substring(0, engraving.Length / 2));
                    var secondStone = long.Parse(engraving.Substring(engraving.Length / 2));
                    var firstNode = new LinkedListNode<long>(firstStone);
                    var secondNode = new LinkedListNode<long>(secondStone);
                    if (currentNode.Previous != null)
                        _stones.AddAfter(currentNode.Previous, firstNode);
                    else
                        _stones.AddFirst(firstNode);
                    _stones.AddAfter(firstNode, secondNode);
                    var nextNode = currentNode.Next;
                    _stones.Remove(currentNode);
                    currentNode = nextNode;
                }
                else
                {
                    currentNode.Value = currentNode.Value * 2024;
                    currentNode = currentNode.Next;
                }
            }
        }
        return _stones.Count().ToString();
    }
}

