namespace Task3.Models
{
    public class GameState
    {
        public string[,] Board { get; set; } = new string[3, 3];
        public string CurrentPlayer { get; set; } = "X"; // Игрок начинает первым
        public string Winner { get; set; }

        public GameState()
        {
            // Инициализация пустой доски
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = null;
                }
            }
        }

        public void MakeMove(int row, int col)
        {
            if (Board[row, col] == null && Winner == null)
            {
                Board[row, col] = CurrentPlayer;

                // Проверим победителя после хода игрока
                if (CheckWinner())
                {
                    Winner = CurrentPlayer;
                }
                else
                {
                    // Переключаем игрока после хода
                    CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";

                    // Если ходит компьютер (нолик)
                    if (CurrentPlayer == "O" && Winner == null)
                    {
                        ComputerMove();
                    }
                }
            }
        }

        // Логика для выбора случайного хода компьютером
        private void ComputerMove()
        {
            Random rand = new Random();
            bool moveMade = false;

            while (!moveMade)
            {
                int row = rand.Next(3);
                int col = rand.Next(3);

                if (Board[row, col] == null)
                {
                    Board[row, col] = "O";
                    moveMade = true;
                }
            }

            // Проверим победителя после хода компьютера
            if (CheckWinner())
            {
                Winner = "O";
            }
            else
            {
                // Переключаем игрока
                CurrentPlayer = "X";
            }
        }

        // Метод для проверки победителя
        private bool CheckWinner()
        {
            // Проверка по строкам, столбцам и диагоналям
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] != null && Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2])
                    return true;
                if (Board[0, i] != null && Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    return true;
            }

            if (Board[0, 0] != null && Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
                return true;
            if (Board[0, 2] != null && Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0])
                return true;

            return false;
        }
    }
}