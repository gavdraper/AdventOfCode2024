using System.Collections.Frozen;
using System.Drawing;
using System.Runtime.CompilerServices;
using AocBase;

var day = new Day8("14", "", "", "");
day.Solve(false);

public class Day8 : Day
{
    
    private Dictionary<char, List<AdvancedPoint>> antennas = new Dictionary<char, List<AdvancedPoint>>();
    
    //367 Too high
    public Day8(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
        string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult,
        expectedResultTwo)
    {
    }
    List<Point> antinodes = new List<Point>();
    protected override string ProcessPartOne()
    {
        for (var y = 0; y < Lines.Count(); y++)
        {
            for (var x = 0; x < Lines[y].Count(); x++)
            {
                var antenna = Lines[y][x];
                if (antenna != '.' && antenna != '\r')
                {
                    if(!antennas.ContainsKey(antenna))
                       antennas.Add(antenna,new List<AdvancedPoint>());
                    antennas[antenna].Add(new AdvancedPoint(Lines.Count(), Lines[y].Count(), x, y));
                }
            }
      
        }

        foreach (var frequency in antennas)
        {
            for (var f = 0; f < frequency.Value.Count-1; f++)
            {
                var fromPoint = frequency.Value[f];
                
                //Inner loop
                for (var f2 = 0; f2 < frequency.Value.Count; f2++)
                {
                    if (f == f2)
                        continue;
                    var toPoint = frequency.Value[f2];
                    var delta = fromPoint.VelocityTo(toPoint);

                    var possibleFirstLocation = fromPoint.Move(delta.Invert());
                    var possibleSecondLocation = toPoint.Move(delta);

                    if (possibleFirstLocation.IsInBounds())
                    {
                        if(!antinodes.Any(p=>p.X == possibleFirstLocation.X && p.Y == possibleFirstLocation.Y))
                            antinodes.Add(possibleFirstLocation.ToPoint());
                    }

                    if (possibleSecondLocation.IsInBounds())
                    {
                        if(!antinodes.Any(p=>p.X == possibleSecondLocation.X && p.Y == possibleSecondLocation.Y))
                        antinodes.Add(possibleSecondLocation.ToPoint());
                    }

                    // PrintMap(
                    //     new List<Point>() { possibleFirstLocation.ToPoint(), possibleSecondLocation.ToPoint() },
                    //     new List<Point>() { fromPoint.ToPoint(), toPoint.ToPoint() }
                    //     , false);
                }
                
            }
        }

     
        PrintMap(new List<Point>(), new List<Point>(),false);
        Console.WriteLine("Biggest X : " +antinodes.OrderByDescending(x => x.X).FirstOrDefault().X);
        Console.WriteLine("Biggest X : " + antinodes.OrderByDescending(x => x.Y).FirstOrDefault().Y);
        
        //should not need this some how getting Y matches out of bounds
        antinodes = antinodes.OrderByDescending(x => x.Y).Where(x=>x.Y != 50).ToList();
        return antinodes.Distinct().Count().ToString();
    }

    public void PrintMap(List<Point> Anti, List<Point> highlight, bool pause)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        for (var y = 0; y < Lines.Count(); y++)
        {

            for (var x = 0; x < Lines[y].Count(); x++)
            {
                if (Anti.Any(p => p.X == x && p.Y == y))
                    Console.ForegroundColor = ConsoleColor.Red;
                else if(highlight.Any(p => p.X == x && p.Y == y))
                    Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                if (antinodes.Any(p => p.X == x && p.Y == y))
                    Console.Write("#");
                else Console.Write(Lines[y][x]);
            }
            Console.WriteLine();

        }
        Console.WriteLine("--------------------------");
        if (pause)
            Console.ReadLine();

    }
    
    protected override string ProcessPartTwo()
    {
        return "World";
    }
}