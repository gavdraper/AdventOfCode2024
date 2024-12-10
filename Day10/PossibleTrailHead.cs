public class PossibleTrailHead(int x, int y, int height)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Score { get; set; }
    public int Height { get; set; } = height;

    public override string ToString()
    {
        return $"{Height} : {Score} : {X},{Y}";
    }
}