namespace DaySeven;

public class Result
{
    public Int64 PartOne { get; set; }
    public Int64 PartTwo { get; set; }

    public Result(Int64 partOne, Int64 partTwo)
    {
        PartOne = partOne;
        PartTwo = partTwo;
    }
}