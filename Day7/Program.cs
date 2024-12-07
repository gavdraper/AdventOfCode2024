// See https://aka.ms/new-console-template for more information

using AocBase;

var day = new Day7("3749","11387","5512534574980","");
day.Solve(true);

public class Day7 : Day
{
    public Day7(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult, string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult, expectedResultTwo)
    {
    }

    protected override string ProcessPartOne()
    {
        long result = 0;
        foreach (var l in Lines)
        {
            var calibration = new Calibration(l);
            if (IsValid(calibration))
                result += calibration.Result;
        }
        return result.ToString();
    }

    private bool IsValid(Calibration calibration, bool combine = false)
    {
        Stack<Calibration> ItemsToCheck = new Stack<Calibration>();
        calibration.Aggregation = calibration.Denominators[0];
        calibration.Index = 1;
        ItemsToCheck.Push(calibration);
        while (ItemsToCheck.Count > 0)
        { 
            calibration = ItemsToCheck.Pop();
            if (calibration.Index == calibration.Denominators.Count() && calibration.Result == calibration.Aggregation)
                return true;
            if (calibration.Index < calibration.Denominators.Count())
            {
                ItemsToCheck.Push(new Calibration()
                {
                    Index = calibration.Index+1, 
                    Denominators = calibration.Denominators,
                    Result = calibration.Result,
                    Aggregation = calibration.Aggregation+ calibration.Denominators[calibration.Index]
                });
                ItemsToCheck.Push(new Calibration()
                {
                    Index = calibration.Index+1, 
                    Denominators = calibration.Denominators,
                    Result = calibration.Result,
                    Aggregation = calibration.Aggregation * calibration.Denominators[calibration.Index]
                });
                // if (combine)
                // {
                //     if (calibration.Denominators.Count() > calibration.Index + 1)
                //     {
                //         ItemsToCheck.Push(new Calibration()
                //         {
                //             Index = calibration.Index + 2,
                //             Denominators = calibration.Denominators,
                //             Result = calibration.Result,
                //             Aggregation = calibration.Aggregation +
                //                           long.Parse((calibration.Denominators[calibration.Index + 1].ToString() +
                //                                       calibration.Denominators[calibration.Index + 1].ToString()))
                //         });
                //         ItemsToCheck.Push(new Calibration()
                //         {
                //             Index = calibration.Index + 2,
                //             Denominators = calibration.Denominators,
                //             Result = calibration.Result,
                //             Aggregation = calibration.Aggregation *
                //                           long.Parse((calibration.Denominators[calibration.Index + 1].ToString() +
                //                                       calibration.Denominators[calibration.Index + 1].ToString()))
                //         });
                //     }
                // }
            }
        }

        return false;

    }

    protected override string ProcessPartTwo()
    {
        long result = 0;
        foreach (var l in Lines)
        {
            var calibration = new Calibration(l);
            if (IsValid(calibration,true))
                result += calibration.Result;
        }
        return result.ToString();
    }
}

public class Calibration
{
    public long Result { get; set; }
    public List<long> Denominators { get; set; }
    public int Index { get; set; } = 0;
    public long Aggregation { get; set; }

    public Calibration(string input)
    {
        var initialSplit = input.Split(":");
        Result = long.Parse(initialSplit[0]);
        Denominators = initialSplit[1].Split(" ").Where(x=>x!=" " && x!="").Select(long.Parse).ToList();
    }
    
    public Calibration(){}
}