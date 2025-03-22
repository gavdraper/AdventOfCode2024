namespace DayThree
{
    internal class Solution
    {
        public Engine Parse(string input)
        {
            var engine = new Engine();
            var lines = input.Split(Environment.NewLine);
            var currentLineNumber = 0;
            foreach (var line in lines)
            {
                var currentColumnNumber = 0;
                var partNumber = "";
                var partStart = -1;
                foreach (var c in line)
                {
                    if (engine.IsSymbol(c))
                        engine.Symbols.Add(new Symbol(currentLineNumber, currentColumnNumber));
                    if(engine.IsGear(c))
                        engine.Gears.Add(new Gear(currentLineNumber, currentColumnNumber));
                    else if (Char.IsDigit(c))
                    {
                        if (partStart == -1)
                            partStart = currentColumnNumber;
                        partNumber += c;
                    }
                    if(!Char.IsDigit(c) | currentColumnNumber == line.Length-1)
                    {
                        if (partStart != -1)
                        {
                            var part = new Part(int.Parse(partNumber), currentLineNumber, partStart, currentColumnNumber - 1);
                            engine.Parts.Add(part);
                            partStart = -1;
                            partNumber = "";
                        }
                    }
                    currentColumnNumber++;
                }
                currentLineNumber++;
            }

            return engine;
        }

        public Result Solve(string input)
        {
            var engine = Parse(input);
            var validParts = new List<Part>();

            foreach (var p in engine.Parts)
            {
                if (engine.SymbolInRange(p))
                    validParts.Add(p);
            }

            var ratios = 0;
            foreach (var g in engine.Gears)
            {
                var numbers = validParts.Where(p =>
                    (g.Row >= p.Row - 1 && g.Row <= p.Row + 1) &&
                    (g.Col >= p.ColStart - 1 && g.Col <= p.ColEnd + 1)).ToList();
                if (numbers.Count == 2)
                    ratios += numbers[0].Number * numbers[1].Number;
            }

            return new Result(validParts.Sum(x => x.Number), ratios);
        }
    }
}
