namespace DayFour
{
    internal class ScratchCard
    {
        public ScratchCard(int id, List<int> winningNumbers, List<int> numbers)
        {
            Id = id;
            WinningNumbers = winningNumbers;
            Numbers = numbers;
        }

        public int Id { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> Numbers { get; set; }
        public int Points { get; set; }
        public int CardCount { get; set; } = 1;

 

    }
}
