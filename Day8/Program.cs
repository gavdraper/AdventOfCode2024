using System.Collections.Frozen;
using System.Drawing;
using System.Runtime.CompilerServices;
using AocBase;

var day = new Day8("14", "34", "359", "1293");
day.Solve(false);

public class Day8 : Day
{
    private Dictionary<char, List<AdvancedPoint>> antennas = new Dictionary<char, List<AdvancedPoint>>();

    public Day8(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
        string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult,
        expectedResultTwo)
    {
    }

    List<Point> _antinodes = new List<Point>();

    public List<Point> Antennas => _antinodes;

    protected override string ProcessPartOne()
    {
        var result =  this.RunSolution(true);
        return result;
    }
    
    protected override string ProcessPartTwo()
    {
        return RunSolution(false);
    }

    private string RunSolution(bool partOne)
    {
       antennas = new Dictionary<char, List<AdvancedPoint>>();
        for (var y = 0; y < Lines.Count(); y++)
        {
            for (var x = 0; x < Lines[y].Count(); x++)
            {
                var antenna = Lines[y][x];
                if (antenna != '.' && antenna != '\r')
                {
                    if (!antennas.ContainsKey(antenna)) antennas.Add(antenna, new List<AdvancedPoint>());
                    antennas[antenna].Add(new AdvancedPoint(Lines.Count(), Lines[y].Count(), x, y));
                }
            }
        }

        foreach (var frequency in antennas)
        {
            for (var f = 0; f < frequency.Value.Count - 1; f++)
            {
                var fromPoint = frequency.Value[f];
                for (var f2 = 0; f2 < frequency.Value.Count; f2++)
                {
                    if (f == f2) continue;
                    var toPoint = frequency.Value[f2];
                    var delta = fromPoint.VelocityTo(toPoint);
                    var possibleFirstLocation = fromPoint.Move(delta.Invert());
                    var possibleSecondLocation = partOne ? toPoint.Move(delta) : fromPoint.Move(delta.Invert()).Move(delta);
                    while (possibleFirstLocation.IsInBounds())
                    {
                        if (!_antinodes.Any(p => p.X == possibleFirstLocation.X && p.Y == possibleFirstLocation.Y))
                            _antinodes.Add(possibleFirstLocation.ToPoint());
                        if (partOne) break;
                        possibleFirstLocation = possibleFirstLocation.Move(delta.Invert());
                    }

                    while (possibleSecondLocation.IsInBounds())
                    {
                        if (!_antinodes.Any(p => p.X == possibleSecondLocation.X && p.Y == possibleSecondLocation.Y))
                            _antinodes.Add(possibleSecondLocation.ToPoint());
                        if (partOne) break;
                        possibleSecondLocation = possibleSecondLocation.Move(delta);
                    }

                    // PrintMap(
                    //     new List<Point>() { possibleFirstLocation.ToPoint(), possibleSecondLocation.ToPoint() },
                    //     new List<Point>() { fromPoint.ToPoint(), toPoint.ToPoint() }
                    //     , false);
                }
            }
        }

        //PrintMap(new List<Point>(), new List<Point>(), false);
        _antinodes = _antinodes.OrderByDescending(x => x.Y).ToList();
        return _antinodes.Distinct().Count().ToString();
    }

    public void PrintMap(List<Point> anti, List<Point> highlight, bool pause)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        for (var y = 0; y < Lines.Count(); y++)
        {
            for (var x = 0; x < Lines[y].Count(); x++)
            {
                if (anti.Any(p => p.X == x && p.Y == y))
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (highlight.Any(p => p.X == x && p.Y == y))
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                if (_antinodes.Any(p => p.X == x && p.Y == y))
                    Console.Write("#");
                else
                    Console.Write(Lines[y][x]);
            }

            Console.WriteLine();
        }

        Console.WriteLine("--------------------------");
        if (pause) Console.ReadLine();
    }

 
}