using AdventBase;
using Xunit;

namespace DayTwo
{
    public class TestHarness : AdventBaseHarness
    {
        [Fact]
        public void TestSolvesSample()
        {
            var solution = new Solution();
            var sample = solution.Solve(SampleInput);
            Assert.Equal(8, sample.SumValidGames);
            Assert.Equal(2286, sample.SumPowers);
            solution = new Solution();
            var real = solution.Solve(RealInput);
        }
    }
} 