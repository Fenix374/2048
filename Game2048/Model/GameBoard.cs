using Game2048.ViewModel.Base;

namespace Game2048.Model
{
    public class GameBoard : ViewModelBase
    {
        public readonly int boardSize = 4;
        public readonly int WinValue = 2048;

        public int[,] board;
        public int score;

        public int[,] Board { get => board; set => Set(ref board, value); }
        public int Score { get => score; set => Set(ref score, value); }

    }
}