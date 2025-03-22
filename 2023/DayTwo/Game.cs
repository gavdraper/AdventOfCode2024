namespace DayTwo
{
    public class Game
    {
        public int Id { get; set; }
        public Dictionary<string, int> Cubes { get; set; } = new Dictionary<string, int>();

        public Game(int id)
        {
            Id = id;
        }
    }
}
