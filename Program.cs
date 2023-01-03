class Program
{
    
    public static void Main(string[] args)
    {
        Console.Title = "Console Sabacc";

        while (true)
        {
            Console.Clear();

            // Main title screen thing
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"     _______.     ___      .______        ___       ______   ______ ");
            Console.WriteLine(@"    /       |    /   \     |   _  \      /   \     /      | /      |");
            Console.WriteLine(@"   |   (----`   /  ^  \    |  |_)  |    /  ^  \   |  ,----'|  ,----'");
            Console.WriteLine(@"    \   \      /  /_\  \   |   _  <    /  /_\  \  |  |     |  |     ");
            Console.WriteLine(@".----)   |    /  _____  \  |  |_)  |  /  _____  \ |  `----.|  `----.");
            Console.WriteLine(@"|_______/    /__/     \__\ |______/  /__/     \__\ \______| \______|");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"                                                                    ");
            Console.WriteLine(@"                                                                    ");
            Console.WriteLine(@"                       PRESS ANY KEY TO START                       ");
            Console.ResetColor();



            // Begin a new game
            Game game = new Game();
            game.Start();
        }

    }

}