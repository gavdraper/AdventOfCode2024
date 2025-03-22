using AdventBase;
using DayFive;
using Xunit;

namespace DayFour
{
    public class TestHarness : AdventBaseHarness
    {
        [Fact]
        public void TestSolvesSample()
        {
            var solution = new Solution();
            var sample = solution.Solve(SampleInput);
            Assert.Equal(35, sample.PartOne);
            Assert.Equal(46, sample.PartTwo);
            //solution = new Solution();
            //var real = solution.Solve(RealInput);
            //Assert.Equal(51580674, real.PartOne);
            //Assert.Equal(6874754, real.PartTwo);
        }
    }
}