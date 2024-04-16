namespace TicTacToe;

public class UIMethods
{

    public static void DisplayWelcomeMessage(string message)
    {
        Console.WriteLine($"\n{message}\n");
    }
    public static void DisplayGrid(string[,] grid, int gridSize, string userMark, string computerMark)
    {
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                    if (j == gridSize - 1)
                    {
                        Console.Write("\n");
                    }
                }
            }
        }
        Console.WriteLine($"\nYour symbol is : {userMark}\nComputer symbol is : {computerMark}\n");
    }

    public static string GetUserChoice(string[,] grid, string wrongChoice)
    {
        Console.WriteLine("Please enter the number of the position on which you want to play : ");
        string userInput = Console.ReadLine();

        if (!Program.CheckUserChoice(grid, userInput))
        {
            Console.Clear();
            Console.WriteLine($"{userInput} is not an authorized value.\n");
            return wrongChoice;
        }

        return userInput;
    }

    public static void EndGameMessage(string[,] grid, string message, int gridSize, string computerMark,
        string userMark)
    {
        Console.Clear();
        DisplayGrid(grid, gridSize, userMark,computerMark);
        Console.WriteLine($"\n{message}");
    }

    public static void ClearUI()
    {
        Console.Clear();
    }
}