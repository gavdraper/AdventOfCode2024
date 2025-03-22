namespace DayThree;

public class Engine
{
    public List<Part> Parts { get; set; } = new List<Part>();
    public List<Gear> Gears { get; set; } = new List<Gear>();
    public List<Symbol> Symbols { get; set; } = new List<Symbol>();

    public bool SymbolInRange(Part part)
    {
        var result = Symbols.Any(x =>
            (x.Row >= part.Row - 1 && x.Row <= part.Row + 1) &&
            (x.Col >= part.ColStart - 1 && x.Col <= part.ColEnd + 1));
        return result;
    }

    public bool IsSymbol(char input)
    {
        return !Char.IsDigit(input) && input != '.';
    }

    public bool IsGear(char input)
    {
        return input == '*';
    }

}