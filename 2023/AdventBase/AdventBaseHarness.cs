namespace AdventBase
{
    public class AdventBaseHarness
    {
        private string sampleInput;
        private string realInput;
        protected string SampleInput
        {
            get
            {
                if (string.IsNullOrEmpty(sampleInput))
                    sampleInput = File.ReadAllText("../../../Input/Sample.txt");
                return sampleInput;
            }
        }

        protected string RealInput
        {
            get
            {
                if (string.IsNullOrEmpty(realInput))
                    realInput = File.ReadAllText("../../../Input/Real.txt");
                return realInput;
            }
        }
    }
}