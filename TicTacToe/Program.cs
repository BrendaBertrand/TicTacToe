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

    static void DisplayGrid(string[,] grid)
    {
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                    if (j == GRID_SIZE - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }
        }
        Console.WriteLine($"\nYour symbol is : {USER_MARK}\nComputer symbol is : {COMPUTER_MARK}\n");
    }

    static bool CheckUserChoice(string[,] grid, string userInput)
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


    static string GetUserChoice(string[,] grid)
    {
        Console.WriteLine("Please enter the number of the position on which you want to play : ");
        string userInput = Console.ReadLine();

        if (!CheckUserChoice(grid, userInput))
        {
            Console.Clear();
            Console.WriteLine($"\n{userInput} is not an authorized value. ");
            return WRONG_CHOICE;
        }

        return userInput;
    }

    static void ReplaceValue(string[,] grid, string mark, string choice)
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
                    break;
                }
            }

            if (isReplaced)
            {
                break;
            }
        }
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
            if (CheckLine(grid, 0))
            {
                return grid[i, 0];
            }

            if (CheckColumn(grid, 0))
            {
                return grid[0, i];
            }
        }

        if (CheckMainDiagonal(grid))
        {
            return grid[0, 0];
        }

        if (CheckMainDiagonal(grid))
        {
            return grid[GRID_SIZE - 1, GRID_SIZE - 1];
        }

        return "";
    }

    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to Tic Tac Toe!\n");

        string[,] grid = new string[GRID_SIZE, GRID_SIZE];
        GridCreation(grid);

        bool isGameOn = true;
        int turn = 0;
        do
        {
          

            if (turn % 2 == 0)
            {
                //User turn
                DisplayGrid(grid);

                string userChoice = GetUserChoice(grid);
                if (userChoice == WRONG_CHOICE)
                {
                    continue;
                }

                ReplaceValue(grid, USER_MARK, userChoice);
            }
            else
            {
                // Computer turn
            }

            switch (GlobalCheck(grid))
            {
                case USER_MARK:
                    Console.Clear();
                    DisplayGrid(grid);
                    Console.WriteLine("\nCongratulations, You Won!");
                    isGameOn = false;
                    break;
                case COMPUTER_MARK:
                    Console.Clear();
                    DisplayGrid(grid);
                    Console.WriteLine("\nGAME OVER. Try Again.");
                    isGameOn = false;
                    break;
            }
            if (isGameOn)
            {
                Console.Clear();
            }
            turn++;
        } while (isGameOn);
    }
}