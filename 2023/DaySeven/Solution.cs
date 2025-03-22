
namespace DaySeven
{
    internal class Solution
    {

        public enum HandType
        {
            High=1000,
            One=1001,
            Two=1002,
            Three=1003,
            Full=1004,
            Four=1005,
            Five=1006
        }


        public class Hand
        {
            public List<char> Cards { get; set; } = new List<char>();
            public int Bid { get; set; }

            private HandType? type = null;

            public HandType Type
            {
                get
                {
                    if (type == null)
                    {
                        var distinct = Cards.Distinct().Count();
                        if (distinct == 5)
                            type = HandType.Five;
                        else if (distinct == 4 && Cards.GroupBy(x=>x).Count)
                            type = HandType.Four;
                        else if (distinct == 3)
                            type = HandType.Full;

                    }

                    return type.Value;
                }
            }

        }

        private Dictionary<char, int> Cards = new Dictionary<char, int>()
        {
            { 'A', 15 },
            { 'K', 14 },
            { 'Q', 13 },
            { 'J', 12 },
            { 'T', 9 },
            { '8', 7 },
            { '6', 5 },
            { '4', 3 },
            { '2', 2 }
        };

        public List<Hand> Parse(string input, bool partTwo)
        {
            var hands = new List<Hand>();
            var lines = input.Split('\n');
            foreach (var l in lines)
            {
                hands.Add(new Hand()
                {
                    Cards = l.Split(" ")[0].Select(x=> (char)x).ToList(),
                    Bid = int.Parse(l.Split(" ")[1])
                });
            }

            return hands;
        }

        public Result Solve(string input)
        {
            var hands = Parse(input, false);

            return new Result(
                -1,
                -1
                );
        }
    }
}
