namespace DayThree;

public class Gear
{
    public Gear(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
    public int Ratio { get; set; }
}