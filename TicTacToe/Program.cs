namespace TicTacToe;

class Program
{
    private const string USER_MARK = "X";
    private const string COMPUTER_MARK = "O";
    private const int GRID_SIZE = 3;
    private const string WRONG_CHOICE = "";

    static void GridCreation(string[,] grid)
    {
        int l = 1;
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                grid[i, j] = (l.ToString());
                l++;
            }
        }
    }

    static void GetFinalGrid(string[,] grid, int turn)
    {
        int countReplacement = 0;
        int i = 1;
        do
        {
            if (ReplaceValue(grid, " ", i.ToString()))
            {
                countReplacement++;
            }
            i++;
        } while (i <= GRID_SIZE * GRID_SIZE && countReplacement <= (GRID_SIZE*GRID_SIZE - turn));
    }

    public static bool CheckUserChoice(string[,] grid, string userInput)
    {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                if (userInput == grid[i, j] && userInput != USER_MARK && userInput != COMPUTER_MARK)
                {
                    return true;
                }
            }
        }

        return false;
    }


   

    static bool ReplaceValue(string[,] grid, string mark, string choice)
    {
        bool isReplaced = false;
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
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
    static bool CheckLine(string[,] array, int line)
    {
        int equal = 0;
        for (int i = 0; i < GRID_SIZE - 1; i++)
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

        return equal == GRID_SIZE - 1;
    }

    //Check column
    static bool CheckColumn(string[,] array, int col)
    {
        int equal = 0;
        for (int i = 0; i < GRID_SIZE - 1; i++)
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

        return equal == GRID_SIZE - 1;
    }

    //Check diagonal
    static bool CheckMainDiagonal(string[,] array)
    {
        int equal = 0;
        for (int i = 0; i < GRID_SIZE - 1; i++)
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

        return equal == GRID_SIZE - 1;
    }

    //Check counter diagonal
    static bool CheckCounterDiagonal(string[,] array)
    {
        int equal = 0;
        for (int i = 0; i < GRID_SIZE - 1; i++)
        {
            if (array[i, (GRID_SIZE - 1) - i] == array[i + 1, (GRID_SIZE - 1) - (i + 1)])
            {
                equal++;
            }
            else
            {
                break;
            }
        }

        return equal == GRID_SIZE - 1;
    }

    static string GlobalCheck(string[,] grid)
    {
        for (int i = 0; i < GRID_SIZE; i++)
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
            return grid[GRID_SIZE - 1, 0];
        }

        return WRONG_CHOICE;
    }

    
    static string FindBestMove(string[,] grid, string mark)
    {
        string[,] testGrid = (string[,])grid.Clone();
        string storedValue = "";
        for (int i = 0; i < GRID_SIZE; i++)
        {
            for (int j = 0; j < GRID_SIZE; j++)
            {
                if (testGrid[i, j] != USER_MARK && testGrid[i, j] != COMPUTER_MARK)
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

        if (mark == USER_MARK)
        {
            return storedValue;
        }
        return WRONG_CHOICE;
    }

    static void Main(string[] args)
    {
        UIMethods.DisplayWelcomMessage("Welcome to Tic Tac Toe!");
       
        string[,] grid = new string[GRID_SIZE, GRID_SIZE];
        GridCreation(grid);

        bool isGameOn = true;
        int turn = 0;
        do
        {
            if (turn % 2 == 0)
            {
                //User turn
                UIMethods.DisplayGrid(grid, GRID_SIZE, USER_MARK,COMPUTER_MARK);

                string userChoice = UIMethods.GetUserChoice(grid, WRONG_CHOICE);
                if (userChoice == WRONG_CHOICE)
                {
                    continue;
                }

                ReplaceValue(grid, USER_MARK, userChoice);
            }
            else
            {
                // Computer turn
                
                string computerChoice = FindBestMove(grid, COMPUTER_MARK); //Value that makes the computer win
                
                if ( computerChoice!= WRONG_CHOICE)
                {
                    ReplaceValue(grid, COMPUTER_MARK, computerChoice);
                }
                else
                {
                    ReplaceValue(grid, COMPUTER_MARK,FindBestMove(grid, USER_MARK));//Value that can block the user
                }
                
            }

            turn++;
            
           
           string globalCheckResult = GlobalCheck(grid);

           if (globalCheckResult != WRONG_CHOICE && turn <GRID_SIZE*GRID_SIZE)
           {
              GetFinalGrid(grid, turn);
           }
           
            if ( globalCheckResult!= WRONG_CHOICE || turn == GRID_SIZE * GRID_SIZE)
            {
                isGameOn = false;
                if (globalCheckResult == USER_MARK)
                {
                    UIMethods.EndGameMessage(grid, "Congratulations, You Won!", GRID_SIZE,COMPUTER_MARK,USER_MARK);
                } 
                if (globalCheckResult == COMPUTER_MARK)
                {
                    UIMethods.EndGameMessage(grid, "GAME OVER. Try Again.", GRID_SIZE,COMPUTER_MARK,USER_MARK);
                }
                if (turn == GRID_SIZE * GRID_SIZE)
                {
                    UIMethods.EndGameMessage(grid, "Draw Game", GRID_SIZE,COMPUTER_MARK,USER_MARK);
                }
            }

            if (isGameOn)
            {
                UIMethods.ClearUI();
            }
            
        } while (isGameOn);
    }
}