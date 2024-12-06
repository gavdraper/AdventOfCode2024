using System.Drawing;
using System.Runtime.CompilerServices;

var input = File.ReadAllText("input.txt");
var lines = input.Split('\n').Select(x => x.ToCharArray()).ToList();

var positions = new Dictionary<string, int>();

var directions = new List<Direction>()
{
    new Direction() { Character = '^', NextCharacter = '>', Velocity = new Point(0, -1) },
    new Direction() { Character = '>', NextCharacter = 'v', Velocity = new Point(1, 0) },
    new Direction() { Character = 'v', NextCharacter = '<', Velocity = new Point(0, 1) },
    new Direction() { Character = '<', NextCharacter = '^', Velocity = new Point(-1, 0) },
};

var currentLocation = FindGuard();

while (InBounds(currentLocation))
{
    if (!positions.TryAdd(currentLocation.X + ":" + currentLocation.Y, 1))
        positions[currentLocation.X + ":" + currentLocation.Y]++;
    var nextLocation = GetNextLocation(currentLocation);
    lines[currentLocation.Y][currentLocation.X] = '.';
    currentLocation = nextLocation.Location;
    if (!InBounds(currentLocation))
        break;
    lines[currentLocation.Y][currentLocation.X] = nextLocation.Facing;
}

Console.WriteLine(positions.Count());
Console.ReadLine();


LocationDirection GetNextLocation(Point currentLocation)
{
    var facing = directions.Single(x=> x.Character == lines[currentLocation.Y][currentLocation.X]);
    while (true)
    {
        var potentialMove = new Point(currentLocation.X + facing.Velocity.X, currentLocation.Y + facing.Velocity.Y);
        if (!InBounds(potentialMove))
            return new LocationDirection() { Location = potentialMove, Facing = facing.Character };
        if (lines[potentialMove.Y][potentialMove.X] == '#')
            facing = directions.Single(x=> x.Character == facing.NextCharacter);
        else  return new LocationDirection() { Location = potentialMove, Facing = facing.Character };
    }
}



Point FindGuard()
{
    for (var i = 0; i < lines.Count(); i++)
    {
        var y = i;
        for (var x = 0; x < lines[i].Count(); x++)
        {
            if (lines[i][x] == '^' || lines[i][x] == 'v' || lines[i][x] == '<' | lines[i][x] == '>')
            {
                return new Point(x, y);
            }
        }
    }

    return new Point(-1, -1);
}

bool InBounds(Point location)
{
    return (
        (location.X >= 0 && location.X < lines[0].Length) &&
        (location.Y >= 0 && location.Y < lines.Count())
    );
}

public class Direction
{
    public char Character { get; set; }
    public char NextCharacter { get; set; }
    public Point Velocity { get; set; }
}

public class LocationDirection
{
    public Point Location { get; set; }
    public char Facing { get; set; }
}