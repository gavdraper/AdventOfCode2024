namespace Day3;

public class MemoryParser
{
    private string _memory;


    public MemoryParser(string memory)
    {
        _memory = memory;
    }

    private bool IsValidInstruction(string? instruction)
    {
        if (!instruction.Contains(","))
            return false;
        var inputs = instruction.Split(",");
        if (inputs.Count() != 2)
            return false;
        foreach (var i in inputs)
            if (!int.TryParse(i, out _))
                return false;
        return true;
    }

    public string? ReadInstruction()
    {
        var enabled = true;
        while (true)
        {
            var potentialStart = _memory.IndexOf("mul(", StringComparison.Ordinal);
            var doInstruction = _memory.IndexOf("do()", StringComparison.Ordinal);
            var dontInstruction = _memory.IndexOf("don't()", StringComparison.Ordinal);
            if (doInstruction < potentialStart && doInstruction > -1)
                enabled = true;
            if (dontInstruction < potentialStart && dontInstruction > -1)
                enabled = false;

            if (potentialStart == -1)
                return null;
            _memory = _memory.Substring(potentialStart + 4);
            var potentialInstructionEnd = _memory.IndexOf(')');
            if (potentialInstructionEnd == -1)
                return null;

            var potentialInstruction = _memory[..potentialInstructionEnd];
            if (!IsValidInstruction(potentialInstruction) || !enabled)
            {
                _memory = _memory.Substring(1);
                continue;
            }

            return potentialInstruction;
        }
    }
}