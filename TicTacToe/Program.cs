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
                //User turn
                UIMethods.DisplayGrid(grid);

                string userChoice = UIMethods.GetUserChoice(grid);
                if (userChoice == Constants.WRONG_CHOICE)
                {
                    continue;
                }

                LogicMethods.ReplaceValue(grid, Constants.USER_MARK, userChoice);
            }
            else
            {
                // Computer turn
                
                string computerChoice = LogicMethods.FindBestMove(grid, Constants.COMPUTER_MARK); //Value that makes the computer win
                
                if ( computerChoice!= Constants.WRONG_CHOICE)
                {
                    LogicMethods.ReplaceValue(grid, Constants.COMPUTER_MARK, computerChoice);
                }
                else
                {
                    LogicMethods.ReplaceValue(grid, Constants.COMPUTER_MARK,LogicMethods.FindBestMove(grid, Constants.USER_MARK));//Value that can block the user
                }
                
            }

            turn++;
            string gameResult = LogicMethods.GlobalCheck(grid);
            isGameOn = LogicMethods.IsGameOn(grid, turn, gameResult);

            if (!isGameOn)
            {
                UIMethods.EndOfGame(grid, turn, gameResult);
            }
            

            if (isGameOn)
            {
                UIMethods.ClearUI();
            }
            
        } while (isGameOn);
    }
}