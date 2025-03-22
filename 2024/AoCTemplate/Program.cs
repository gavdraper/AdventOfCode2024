using AocBase;

var day = new DayX("","","","");
day.Solve(true);

public class DayX : Day
{
    public DayX(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
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