class Program
{
    
    public static void Main(string[] args)
    {
        Console.Title = "Console Sabacc";

        // Main title screen thing
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"     _______.     ___      .______        ___       ______   ______ ");
        Console.WriteLine(@"    /       |    /   \     |   _  \      /   \     /      | /      |");
        Console.WriteLine(@"   |   (----`   /  ^  \    |  |_)  |    /  ^  \   |  ,----'|  ,----'");
        Console.WriteLine(@"    \   \      /  /_\  \   |   _  <    /  /_\  \  |  |     |  |     ");
        Console.WriteLine(@".----)   |    /  _____  \  |  |_)  |  /  _____  \ |  `----.|  `----.");
        Console.WriteLine(@"|_______/    /__/     \__\ |______/  /__/     \__\ \______| \______|");
        Console.ResetColor();



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