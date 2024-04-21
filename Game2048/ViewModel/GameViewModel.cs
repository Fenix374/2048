using System;
using Game2048.Data;
using Game2048.Model;
using System.Windows;
using Game2048.Commands;
using Game2048.ViewModel.Base;

namespace Game2048.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private GameBoard gameBoard;
        private Random random;
        public int[,] Board { get => gameBoard.board; private set => Set(ref gameBoard.board, value); }
        public int Score { get => gameBoard.score; private set => Set(ref gameBoard.score, value); }
        public GameViewModel()
        {
            gameBoard = new();
            random = new();
            Reset();
        }

        #region CommandsRelay~Navigation
        public NavigationCommand NavigateToMenuPage
        { get => new(NavigateToPage, new Uri("View/Page/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }

        public RelayCommand ShiftLeftCommand { get => new(ShiftLeft); }
        public RelayCommand ShiftRightCommand { get => new(ShiftRight); }
        public RelayCommand ShiftUpCommand { get => new(ShiftUp); }
        public RelayCommand ShiftDownCommand { get => new(ShiftDown); }

        public RelayCommand ResetCommand { get => new(Reset); }
        #endregion

        #region CommandsBase
        private void Reset()
        {
            Board = new int[gameBoard.boardSize, gameBoard.boardSize];
            Score = 0;
            GenerateRandomNumber();
            GenerateRandomNumber();
            Update();
        }

        private void GenerateRandomNumber()
        {
            int row, col;
            do
            {
                row = random.Next(gameBoard.boardSize);
                col = random.Next(gameBoard.boardSize);
            } while (gameBoard.board[row, col] != 0);
            gameBoard.board[row, col] = random.Next(100) < 90 ? 2 : 4;
        }

        private void Update()
        {
            Board = gameBoard.Board;
            Score = gameBoard.Score;
        }
        #endregion

        #region CommandsGameState
        private void CheckGameState()
        {
            Update();
            if (Loser())
            {
                MessageBoxResult result = MessageBox.Show("Хочешь сохранить свой прогресс?", "You're a loser",
                    MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }
                Reset();
            }
            else if (Winner())
            {
                MessageBoxResult result = MessageBox.Show("Хочешь сохранить свой прогресс?", "You're a winner",
                    MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    AddToStatistics();
                }
                Reset();
            }
        }

        public void AddToStatistics()
        {
            string name;
            do
            {
                name = Microsoft.VisualBasic.Interaction.InputBox("ВВЕДИТЕ ВАШЕ ИМЯ", "~2048~", "");
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Обратного пути нет. Введи свое имя!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } while (string.IsNullOrEmpty(name));

            Statistics.Add(name, Score.ToString());
        }

        public bool Winner()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int col = 0; col < gameBoard.boardSize; col++)
                {
                    if (gameBoard.board[row, col] == gameBoard.WinValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Loser()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int col = 0; col < gameBoard.boardSize; col++)
                {
                    if (gameBoard.board[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int col = 0; col < gameBoard.boardSize; col++)
                {
                    int value = gameBoard.board[row, col];

                    if (row > 0 && gameBoard.board[row - 1, col] == value)
                    {
                        return false;
                    }
                    if (row < gameBoard.boardSize - 1 && gameBoard.board[row + 1, col] == value)
                    {
                        return false;
                    }
                    if (col > 0 && gameBoard.board[row, col - 1] == value)
                    {
                        return false;
                    }
                    if (col < gameBoard.boardSize - 1 && gameBoard.board[row, col + 1] == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region CommandsShifts
        public void ShiftLeft()
        {
            bool shifted = false;
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                int index = 0;
                for (int j = 0; j < gameBoard.board.GetLength(1); j++)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index > 0 && gameBoard.board[i, index - 1] == gameBoard.board[i, j])
                        {
                            gameBoard.board[i, index - 1] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[i, index - 1];
                        }
                        else
                        {
                            if (j != index)
                            {
                                gameBoard.board[i, index] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }
            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }
        public void ShiftRight()
        {
            bool shifted = false;
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                int index = gameBoard.board.GetLength(1) - 1;
                for (int j = gameBoard.board.GetLength(1) - 1; j >= 0; j--)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index < gameBoard.board.GetLength(1) - 1 && gameBoard.board[i, index + 1] == gameBoard.board[i, j])
                        {
                            gameBoard.board[i, index + 1] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[i, index + 1];
                        }
                        else
                        {
                            if (j != index)
                            {
                                gameBoard.board[i, index] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }

                    }
                }
            }
            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }

        public void ShiftDown()
        {
            bool shifted = false;
            for (int j = 0; j < gameBoard.board.GetLength(1); j++)
            {
                int index = gameBoard.board.GetLength(0) - 1;
                for (int i = gameBoard.board.GetLength(0) - 1; i >= 0; i--)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index < gameBoard.board.GetLength(0) - 1 && gameBoard.board[index + 1, j] == gameBoard.board[i, j])
                        {
                            gameBoard.board[index + 1, j] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[index + 1, j];
                        }
                        else
                        {
                            if (i != index)
                            {
                                gameBoard.board[index, j] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }
                    }
                }
            }
            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }
        public void ShiftUp()
        {
            bool shifted = false;
            for (int j = 0; j < gameBoard.board.GetLength(1); j++)
            {
                int index = 0;
                for (int i = 0; i < gameBoard.board.GetLength(0); i++)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index > 0 && gameBoard.board[index - 1, j] == gameBoard.board[i, j])
                        {
                            gameBoard.board[index - 1, j] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[index - 1, j];
                        }
                        else
                        {
                            if (i != index)
                            {
                                gameBoard.board[index, j] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }
            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }
        #endregion
    }
}