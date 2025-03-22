using System.Drawing;
using System.Runtime.Intrinsics.X86;

public class AdvancedPoint(int maxX, int maxY, int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public AdvancedPoint VelocityTo(AdvancedPoint toLocation)
    {
        return new AdvancedPoint(maxX,maxY,toLocation.X - X, toLocation.Y - Y );
    }

    public bool IsInBounds() =>
        X >= 0 &&
        Y >= 0 &&
        X < maxX &&
        Y < maxY;
    
    public Point ToPoint() => new Point(X, Y);

    public AdvancedPoint Invert() => new AdvancedPoint(maxX, maxY, -X, -Y);
    
    public AdvancedPoint Move(AdvancedPoint velocity)
    {
        return new AdvancedPoint(maxX, maxY, X+ velocity.X, Y + velocity.Y);
    }



}