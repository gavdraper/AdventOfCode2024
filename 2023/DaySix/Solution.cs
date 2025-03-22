
namespace DaySix
{
    internal class Solution
    {
        private List<long> times,distances,margins;

        public void Parse(string input, bool partTwo)
        {
            input = input.Replace("Time:", "").Replace("Distance:", "");
            if (partTwo)
                input = input.Replace(" ", "");
            var lines = input.Split(Environment.NewLine);
            times = lines[0].Split(" ").Where(x=>x!="").Select(long.Parse).ToList();
            distances = lines[1].Split(" ").Where(x => x != "").Select(long.Parse).ToList();
            margins = new List<long>();
        }

        private void CalcMargins()
        {
            for (var i=0;i<times.Count;i++)
            {
                long firstWin=-1,lastWin = -1;
                for (var chargeTime = 1; chargeTime <= times[i]; chargeTime++)
                {
                    if (((times[i] - chargeTime) * chargeTime)  > distances[i])
                    {
                        if (firstWin == -1)
                            firstWin = chargeTime;
                        if (chargeTime == times[i])
                            lastWin = chargeTime;
                    }
                    else
                    {
                        if (firstWin != -1)
                        {
                            lastWin = chargeTime - 1;
                            break;
                        }
                    }
                }
                margins.Add(lastWin - (firstWin - 1));
            }
        }

        public Result Solve(string input)
        {
            Parse(input,false);
            CalcMargins();
            var partOne = margins.Aggregate((long)1, (x, y) => x * y);

            Parse(input,true);
            CalcMargins();
            var partTwo = margins.Aggregate((long)1, (x, y) => x * y);

            return new Result(
                partOne,
                partTwo
                );
        }
    }
}
