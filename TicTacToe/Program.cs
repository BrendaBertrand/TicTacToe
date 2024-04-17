namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage("Welcome to Tic Tac Toe!");

        string[,] grid = new string[Constants.GRID_SIZE, Constants.GRID_SIZE];
        LogicMethods.GridCreation(grid);

        bool isGameOn = true;
        int turn = 0;
        do
        {
            if (turn % 2 == 0)
            {
                UIMethods.UserTurn(grid);
            }
            else
            {
                LogicMethods.ComputerTurn(grid);
            }

            turn++;
            string gameResult = LogicMethods.GlobalCheck(grid);
            isGameOn = LogicMethods.IsGameOn(grid, turn, gameResult);
            
            if (isGameOn)
            {
                UIMethods.ClearUI();
            }
            else
            {
                UIMethods.EndOfGame(grid, turn, gameResult);
            }
        } while (isGameOn);
    }
}