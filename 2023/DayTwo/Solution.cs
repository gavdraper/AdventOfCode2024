using System.Diagnostics;

namespace DayTwo
{

    internal class Solution
    {

        public List<Game> Games = new List<Game>();
        public Dictionary<string, int> TotalCubeCounts = new Dictionary<string, int>
        {
            {"red",12 },
            {"green",13 },
            {"blue",14 }
        };

        private Game Parse(string line)
        {
            var cubesRaw = line.Replace(";", ",").Replace(":", ",").Split(",");
            var game = new Game(int.Parse(cubesRaw[0].Split(" ")[1]));
            for (var i = 1; i < cubesRaw.Length; i++)
            {
                var colorCount = cubesRaw[i].Trim().Split(" ");
                if (game.Cubes.ContainsKey(colorCount[1])
                    && int.Parse(colorCount[0]) > game.Cubes[colorCount[1]])
                    game.Cubes[colorCount[1]] = int.Parse(colorCount[0]);
                else if(!game.Cubes.ContainsKey(colorCount[1]))
                    game.Cubes.Add(colorCount[1], int.Parse(colorCount[0]));
            }
            return game;
        }


        public Result Solve(string input)
        {
            foreach (var l in input.Split(Environment.NewLine))
                Games.Add(Parse(l));
            var powers = 0;
            var sumValidGames = 0;
            for (var i = 0; i < Games.Count(); i++)
            {
                var gameId = Games[i].Id;
                var valid = true;
                var power = 1;
                foreach (var c in Games[i].Cubes)
                {
                    power = power * c.Value;
                    if ((c.Value > 0 && !TotalCubeCounts.ContainsKey(c.Key)) |
                        TotalCubeCounts[c.Key] < c.Value)
                        valid = false;
                }
                if (valid)
                    sumValidGames += (gameId);
                powers += power;
                
            }
            return new Result() { SumValidGames = sumValidGames, SumPowers = powers};
        }
    }
}
