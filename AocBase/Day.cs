namespace AocBase;

public abstract class Day
{
    private List<string> _lines = new List<string>();
    public string PartOneResult { get; set; }
    public string PartTwoResult { get; set; }
    public string Input { get; set; }

    public List<string> Lines
    {
        get
        {
            if (_lines == null || _lines.Count == 0)
            {
                _lines = Input.Split("\n").ToList();
            }

            return _lines;
        }
    }

    public abstract string ProcessPartOne();
    public abstract string ProcessPartTwo();

    public void Solve()
    {
        PartOneResult = ProcessPartOne();
        PartTwoResult = ProcessPartTwo();
        Console.WriteLine("Part One Result : " + PartOneResult);
        Console.WriteLine("Part Two Result : " + PartTwoResult);
    }

    public Day()
    {
        Input = File.ReadAllText("input.txt");
    }
}