namespace TicTacToe;

public class UIMethods
{
    public static void DisplayWelcomeMessage(string message)
    {
        Console.WriteLine($"\n{message}\n");
    }

    public static void DisplayGrid(string[,] grid)
    {
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                    if (j == Constants.GRID_SIZE - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }
        }
        Console.WriteLine(
            $"\nYour symbol is : {Constants.USER_MARK}\nComputer symbol is : {Constants.COMPUTER_MARK}\n");
    }

    public static string GetUserChoice(string[,] grid)
    {
        Console.WriteLine("Please enter the number of the position on which you want to play : ");
        string userInput = Console.ReadLine();

        if (!LogicMethods.CheckUserChoice(grid, userInput))
        {
            Console.Clear();
            Console.WriteLine($"{userInput} is not an authorized value.\n");
            return Constants.WRONG_CHOICE;
        }

        return userInput;
    }


    public static void ClearUI()
    {
        Console.Clear();
    }

    public static void EndOfGame(string [,] grid, int turn, string result )
    {
        LogicMethods.GetFinalGrid(grid, turn);
        Console.Clear();
        DisplayGrid(grid);
        
        if (result == Constants.USER_MARK)
        {
            Console.WriteLine("Congratulations, You Won!");
        } 
        else if (result == Constants.COMPUTER_MARK)
        {
            Console.WriteLine("GAME OVER. Try Again.");
        }
        else if (turn == Constants.GRID_SIZE * Constants.GRID_SIZE)
        {
            Console.WriteLine("Draw Game");
        }
        
    }
    
    public static void UserTurn(string[,] grid)
    {
        string userChoice = Constants.WRONG_CHOICE;
        do
        {
            DisplayGrid(grid);

            userChoice = GetUserChoice(grid);
            
        } while (userChoice == Constants.WRONG_CHOICE);
        
        LogicMethods.ReplaceValue(grid, Constants.USER_MARK, userChoice);
    }
}