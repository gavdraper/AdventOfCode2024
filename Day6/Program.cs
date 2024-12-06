using System.Drawing;
using System.Runtime.CompilerServices;

var input = File.ReadAllText("input.txt");
var lines = input.Split('\n').Select(x => x.ToCharArray()).ToList();
var walkedPositions = new List<Point>();
var positions = new Dictionary<string, int>();

var directions = new List<Direction>()
{
    new() { Character = '^', NextCharacter = '>', Velocity = new Point(0, -1) },
    new() { Character = '>', NextCharacter = 'v', Velocity = new Point(1, 0) },
    new() { Character = 'v', NextCharacter = '<', Velocity = new Point(0, 1) },
    new() { Character = '<', NextCharacter = '^', Velocity = new Point(-1, 0) },
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
    if(!walkedPositions.Any(x=>x.X == currentLocation.X && x.Y == currentLocation.Y))
    walkedPositions.Add(currentLocation);
    lines[currentLocation.Y][currentLocation.X] = nextLocation.Facing;
}

//Part 2
var timeWarpOptions = 0;
for (var i = 0; i < walkedPositions.Count; i++)
{
    var partTwoWalkedPositions = new List<LocationDirection>();
    lines = input.Split('\n').Select(x => x.ToCharArray()).ToList();
    currentLocation = FindGuard();
    if (currentLocation.X == walkedPositions[i].X && currentLocation.Y == walkedPositions[i].Y)
        continue;
    lines[walkedPositions[i].Y][walkedPositions[i].X] = '#';
    while (InBounds(currentLocation))
    {
        var nextLocation = GetNextLocation(currentLocation);
        lines[currentLocation.Y][currentLocation.X] = '.';
        currentLocation = nextLocation.Location;
        if (!InBounds(currentLocation))
            break;
        if (partTwoWalkedPositions.Any(x => x.Location.X == currentLocation.X && x.Location.Y == currentLocation.Y && x.Facing == nextLocation.Facing))
        {
            timeWarpOptions++;
            break;
        }
        partTwoWalkedPositions.Add(nextLocation);
        lines[currentLocation.Y][currentLocation.X] = nextLocation.Facing;
    }
}

Console.WriteLine("Part 1 " + positions.Count());
Console.WriteLine("Part 2 " + timeWarpOptions);
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