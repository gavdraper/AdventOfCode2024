// See https://aka.ms/new-console-template for more information

using AocBase;

var day = new Day7("","","","");
day.Solve(false);

public class Day7 : Day
{
    public Day7(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult, string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult, expectedResultTwo)
    {
    }

    protected override string ProcessPartOne()
    {
        return Lines.Last();

    }

    protected override string ProcessPartTwo()
    {
        return Lines.First();
    }
}