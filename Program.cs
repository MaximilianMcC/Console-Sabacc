class Program
{
    
    public static void Main(string[] args)
    {
        Console.Title = "Console Sabacc";


        // Begin a new game
        Game game = new Game();
        game.Start();

        // Play the game
        game.Round();
        game.Round();
        game.Round();

        // Check for who the winner is 
        game.End();


        Console.WriteLine("\n\nEnd of program...");
        Console.ReadKey();
    }

}