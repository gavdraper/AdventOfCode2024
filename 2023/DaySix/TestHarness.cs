using AdventBase;
using Xunit;

namespace DaySix
{
    public class TestHarness : AdventBaseHarness
    {
        [Fact]
        public void TestSolvesSample()
        {
            var solution = new Solution();
            var sample = solution.Solve(SampleInput);
            Assert.Equal(288, sample.PartOne);
             Assert.Equal(71503, sample.PartTwo);
            solution = new Solution();
            var real = solution.Solve(RealInput);
            Assert.Equal(1731600, real.PartOne);
            Assert.Equal(40087680, real.PartTwo);
        }
    }
}