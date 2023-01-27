class Program
{
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Sabacc\n\n\n");


        Game game = new Game();
        game.NewGame();

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}