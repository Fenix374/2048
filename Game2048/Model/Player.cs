namespace Game2048.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string Score { get; set; }

        public Player(string name, string score)
        {
            Name = name;
            Score = score;
        }
    }
}