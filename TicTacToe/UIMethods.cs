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

    public static void EndGameMessage(string[,] grid, string message)
    {
        Console.Clear();
        DisplayGrid(grid);
        Console.WriteLine($"\n{message}");
    }

    public static void ClearUI()
    {
        Console.Clear();
    }
}