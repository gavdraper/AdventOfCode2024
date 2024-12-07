using AocBase;

var day = new Day8("","","","");
day.Solve(true);

public class Day8 : Day
{
    public Day8(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
        string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult,
        expectedResultTwo)
    {
    }

    protected override string ProcessPartOne()
    {
        return "Hello";
    }

    protected override string ProcessPartTwo()
    {
        return "World";
    }
}