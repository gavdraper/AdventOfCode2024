namespace DayOneTest
{
    internal class Solution
    {
        public Dictionary<string, string> Matches = new()
        {
            { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" },
            { "five", "5" }, { "six", "6"}, { "seven", "7"}, { "eight", "8"},
            { "nine", "9"}, {"1","1"}, {"2","2"}, {"3","3"}, {"4","4"}, {"5","5"},
            {"6","6"}, {"7","7"}, {"8","8"}, {"9","9"},
        };


        public int FindFirstAndLast(string input)
        {
            string? first = null, last = null;

            //Walk Forward
            for (var i = 0; i < input.Length; i++)
            {
                foreach (var m in Matches)
                {
                    if (input.IndexOf(m.Key) == i)
                    {
                        first = m.Value;
                        break;
                    }
                }
                if (first != null) break;
            }

            //Walk Back
            for (var i = input.Length - 1; i >= 0; i--)
            {
                foreach (var m in Matches)
                {
                    if (input.LastIndexOf(m.Key) == i)
                    {
                        last = m.Value;
                        break;
                    }
                }
                if (last != null) break;
            }

            return int.Parse(first + last);
        }

        public int Solve(string input)
        {
            var digits = new List<int>();
            foreach (var l in input.Split(Environment.NewLine))
                digits.Add(FindFirstAndLast(l.ToLower()));
            return digits.Sum();
        }
    }
}
