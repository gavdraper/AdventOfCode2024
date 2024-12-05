using Day3;

var memory = File.ReadAllText("input.txt");

var Instructions = new List<InstructionCalculator>();

var parser = new MemoryParser(memory);

var currentInstruction = parser.ReadInstruction();
while (currentInstruction != null)
{
    Instructions.Add(new InstructionCalculator(currentInstruction));
    currentInstruction = parser.ReadInstruction();
}

Console.WriteLine(Instructions.Select(x=>x.Result).Sum());