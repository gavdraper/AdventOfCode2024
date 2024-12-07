using System.Drawing;

namespace AocBase;

public abstract class Day
{
    private readonly string _expectedResultTwo;
    private readonly string _expectedSampleResult;
    private readonly string _expectedSampleResultTwo;
    private readonly string _expectedResult;
    private List<string>? _lines = [];

    protected Day(string expectedSampleResult="", string expectedSampleResultTwo="", string expectedResult="",string expectedResultTwo="")
    {
        _expectedResultTwo = expectedResultTwo;
        _expectedSampleResult = expectedSampleResult;
        _expectedSampleResultTwo = expectedSampleResultTwo;
        _expectedResult = expectedResult;
    }



    private string? PartOneResult { get; set; }
    private string? PartTwoResult { get; set; }
    private string? Input { get; set; }

    protected List<string> Lines
    {
        get
        {
            if (_lines == null || _lines.Count == 0)
                if (Input != null)
                    _lines = Input.Split("\n").ToList();

            return _lines;
        }
    }

    protected abstract string ProcessPartOne();
    protected abstract string ProcessPartTwo();

    public void Solve(bool sample)
    {        
        Input = sample ? File.ReadAllText("sample.txt") : File.ReadAllText("input.txt");
        PartOneResult = ProcessPartOne();
        PartTwoResult = ProcessPartTwo();
        Console.WriteLine("RESULTS " + (sample ? " (SAMPLE)":""));
        Console.WriteLine("Part One Result : " + PartOneResult);
        if (sample && !string.IsNullOrEmpty(_expectedSampleResult))
            WritePassFail((_expectedSampleResult == PartOneResult ? "PASS":"FAIL Expected " + _expectedSampleResult));
        if (!sample && !string.IsNullOrEmpty(_expectedResult))
            WritePassFail( (_expectedResult == PartOneResult ? "PASS":"FAIL Expected " + _expectedResult));
        Console.WriteLine("Part Two Result : " + PartTwoResult);
        if (sample && !string.IsNullOrEmpty(_expectedSampleResultTwo))
            WritePassFail( (_expectedSampleResultTwo == PartTwoResult ? "PASS":"FAIL Expected " + _expectedSampleResultTwo));
        if (!sample && !string.IsNullOrEmpty(_expectedResult))
            WritePassFail((_expectedResultTwo == PartTwoResult ? "PASS":"FAIL Expected " + _expectedResultTwo));
    }

    private void WritePassFail(string message)
    {
        if (message.Contains("FAIL"))
            Console.ForegroundColor = ConsoleColor.Red;
        else Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}