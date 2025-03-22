var input = File.ReadAllText("input.txt");
var lines = input.Split('\n');

var reports = lines.Select(x => new Report(x));

Console.WriteLine("Part 1");
Console.WriteLine(reports.Count(x => x.Status == "safe"));

Console.WriteLine("----------------");
Console.WriteLine("Test Pass/Fail");
if (reports.Count(x => x.Status == "safe") == 569)
    Console.WriteLine("Pass");
else Console.WriteLine("Fail");

Console.ReadLine();


public enum Direction
{
    Ascending,
    Descending
}

public class Report
{
    public Report(string levels)
    {
        Levels = levels.Split(' ').Select(int.Parse).ToList();
        for (var i = 0; i < Levels.Count; i++)
        {
            var newLevels = new List<int>(Levels);
            newLevels.Remove(i);
            Status = CalculateStatus(newLevels);
            if (Status == "safe")
                break;
        }
    }

    public List<int> Levels { get; set; }
    public string Status { get; set; }

    private bool IsValidLevel(int previous, int current, Direction direction)
    {
        var delta = previous - current;
        if (Math.Abs(delta) < 1 || Math.Abs(delta) > 3)
            return false;
        return (direction == Direction.Descending && current <= previous) ||
               (direction == Direction.Ascending && current >= previous);
    }

    private string CalculateStatus(List<int> levels)
    {
        var result = "safe";
        var direction = Direction.Ascending;
        for (var i = 1; i < levels.Count(); i++)
        {
            var current = levels[i];
            var previous = levels[i - 1];

            if (i == 1 && current < previous)
                direction = Direction.Descending;

            if (!IsValidLevel(previous, current, direction))
                result = "unsafe";
        }

        return result;
    }
}