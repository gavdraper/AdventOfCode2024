﻿namespace DayThree;

public class Symbol
{
    public Symbol(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public int Row { get; set; }
    public int Col { get; set; }
}