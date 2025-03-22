namespace DayThree;

public class Part
{
    public int Number { get; }
    public int Row { get; set; }
    public int ColStart { get; set; }
    public int ColEnd { get; set; }

    public Part(int number, int row, int colStart, int colEnd)
    {
        Number = number;
        Row = row;
        ColStart = colStart;
        ColEnd = colEnd;
    }
}