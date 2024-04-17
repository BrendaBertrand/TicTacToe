namespace TicTacToe;

public class LogicMethods
{
    public static void GridCreation(string[,] grid)
    {
        int l = 1;
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                grid[i, j] = (l.ToString());
                l++;
            }
        }
    }

    public static void GetFinalGrid(string[,] grid, int turn)
    {
        int countReplacement = 0;
        int i = 1;
        while (i <= Constants.GRID_SIZE * Constants.GRID_SIZE &&
               countReplacement < (Constants.GRID_SIZE * Constants.GRID_SIZE - turn))

        {
            if (ReplaceValue(grid, " ", i.ToString()))
            {
                countReplacement++;
            }

            i++;
        }
    }

    public static bool CheckUserChoice(string[,] grid, string userInput)
    {
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                if (userInput == grid[i, j] && userInput != Constants.USER_MARK && userInput != Constants.COMPUTER_MARK)
                {
                    return true;
                }
            }
        }

        return false;
    }


    public static bool ReplaceValue(string[,] grid, string mark, string choice)
    {
        bool isReplaced = false;
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                if (grid[i, j] == choice)
                {
                    grid[i, j] = mark;
                    isReplaced = true;
                    return isReplaced;
                }
            }
        }

        return isReplaced;
    }


    //Check line
    public static bool CheckLine(string[,] array, int line)
    {
        int equal = 0;
        for (int i = 0; i < Constants.GRID_SIZE - 1; i++)
        {
            if (array[line, i] == array[line, i + 1])
            {
                equal++;
            }
            else
            {
                break;
            }
        }

        return equal == Constants.GRID_SIZE - 1;
    }

    //Check column
    public static bool CheckColumn(string[,] array, int col)
    {
        int equal = 0;
        for (int i = 0; i < Constants.GRID_SIZE - 1; i++)
        {
            if (array[i, col] == array[i + 1, col])
            {
                equal++;
            }
            else
            {
                break;
            }
        }

        return equal == Constants.GRID_SIZE - 1;
    }

    //Check diagonal
    public static bool CheckMainDiagonal(string[,] array)
    {
        int equal = 0;
        for (int i = 0; i < Constants.GRID_SIZE - 1; i++)
        {
            if (array[i, i] == array[i + 1, i + 1])
            {
                equal++;
            }
            else
            {
                break;
            }
        }

        return equal == Constants.GRID_SIZE - 1;
    }

    //Check counter diagonal
    public static bool CheckCounterDiagonal(string[,] array)
    {
        int equal = 0;
        for (int i = 0; i < Constants.GRID_SIZE - 1; i++)
        {
            if (array[i, (Constants.GRID_SIZE - 1) - i] == array[i + 1, (Constants.GRID_SIZE - 1) - (i + 1)])
            {
                equal++;
            }
            else
            {
                break;
            }
        }

        return equal == Constants.GRID_SIZE - 1;
    }

    public static string GlobalCheck(string[,] grid)
    {
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            if (CheckLine(grid, i))
            {
                return grid[i, 0];
            }

            if (CheckColumn(grid, i))
            {
                return grid[0, i];
            }
        }

        if (CheckMainDiagonal(grid))
        {
            return grid[0, 0];
        }

        if (CheckCounterDiagonal(grid))
        {
            return grid[Constants.GRID_SIZE - 1, 0];
        }

        return Constants.WRONG_CHOICE;
    }


    public static string FindBestMove(string[,] grid, string mark)
    {
        string[,] testGrid = (string[,])grid.Clone();
        string storedValue = "";
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                if (testGrid[i, j] != Constants.USER_MARK && testGrid[i, j] != Constants.COMPUTER_MARK)
                {
                    storedValue = testGrid[i, j];
                    ReplaceValue(testGrid, mark, storedValue);

                    if (GlobalCheck(testGrid) == mark)
                    {
                        return storedValue;
                    }

                    testGrid[i, j] = storedValue;
                }
            }
        }

        if (mark == Constants.USER_MARK)
        {
            return storedValue;
        }

        return Constants.WRONG_CHOICE;
    }

    public static bool IsGameOn(string[,] grid, int turn, string result)
    {
        if (result != Constants.WRONG_CHOICE || turn == Constants.GRID_SIZE * Constants.GRID_SIZE)
        {
            return false;
        }

        return true;
    }

    public static void ComputerTurn(string[,] grid)
    {
        string computerChoice = LogicMethods.FindBestMove(grid, Constants.COMPUTER_MARK); //Value that makes the computer win
                
        if ( computerChoice!= Constants.WRONG_CHOICE)
        {
            ReplaceValue(grid, Constants.COMPUTER_MARK, computerChoice);
        }
        else
        {
            ReplaceValue(grid, Constants.COMPUTER_MARK,LogicMethods.FindBestMove(grid, Constants.USER_MARK));//Value that can block the user
        }
    }


}