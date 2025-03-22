namespace DayFour
{

    internal class Solution
    {
        private ScratchCard Parse(string line)
        {
            var gameAndNumbers = line.Split(":");
            var numbers = gameAndNumbers[1].Split("|");
            var winningNumbers = numbers[0].Split(' ').Where(x => x != "").Select(x => int.Parse(x)).ToList();
            var cardNumbers = numbers[1].Split(' ').Where(x => x != "").Select(x => int.Parse(x)).ToList();
            var id = int.Parse(line.Substring(5, line.IndexOf(":") - 5));
            return new ScratchCard(id, winningNumbers, cardNumbers);

        }

        public Result Solve(string input)
        {
            var cards = new Dictionary<int, ScratchCard>();
            var lines = input.Split(Environment.NewLine);

            //Part One
            foreach (var l in lines)
            {
                var total = 0;
                var card = Parse(l);
                foreach (var n in card.Numbers)
                {
                    if (card.WinningNumbers.Contains(n))
                    {
                        if (total == 0)
                            total = 1;
                        else total *= 2;
                    }
                }
                card.Points = total;
                cards.Add(card.Id, card);
            }

            //Part 2
            foreach (var c in cards.Values)
            {
                var winCount = c.Numbers.Count(x => c.WinningNumbers.Contains(x));
                for (var i = c.Id + 1; i <= (c.Id + winCount); i++)
                {
                    if (cards.ContainsKey(i))
                        cards[i].CardCount += c.CardCount;
                }
            }

            return new Result(
                cards.Values.Sum(x => x.Points), 
                cards.Values.Sum(x => x.CardCount));
        }
    }
}
