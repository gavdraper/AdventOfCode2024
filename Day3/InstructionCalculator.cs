public class InstructionCalculator
{
    private readonly int _first;
    private readonly int _second;

    public InstructionCalculator(string instruction)
    {
        var stripedInstruction = instruction
            .Replace("mul(", "")
            .Replace(")", "")
            .Split(",")
            .Select(int.Parse)
            .ToList();

        _first = stripedInstruction[0];
        _second = stripedInstruction[1];
    }

    public int Result => _first * _second;
}