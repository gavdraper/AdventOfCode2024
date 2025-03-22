using AdventBase;
using DayThree;
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
            Assert.Equal(4361, sample.Parts);
            Assert.Equal(467835, sample.Ratios);
            solution = new Solution();
            var real = solution.Solve(RealInput);
            Assert.Equal(550934, real.Parts);
            Assert.Equal(81997870, real.Ratios);
        }
    }
} 