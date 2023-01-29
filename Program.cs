class Program
{
    
    static bool animationPlaying = true;

    static void Main(string[] args)
    {
        // Make a star background
        Random random = new Random();
        for (int y = 0; y < Console.WindowHeight; y++)
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                if (random.Next(1, 15) == 1) Console.Write('*');
                else Console.Write(' ');
            }

            Console.Write("\n");
        }

        // Main Sabacc menu
        Console.SetCursorPosition(0, 5);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n\n\n\n");
        // CentreText(@"     _______.     ___      .______        ___       ______   ______ ");
        // CentreText(@"    /       |    /   \     |   _  \      /   \     /      | /      |");
        // CentreText(@"   |   (----`   /  ^  \    |  |_)  |    /  ^  \   |  ,----'|  ,----'");
        // CentreText(@"    \   \      /  /_\  \   |   _  <    /  /_\  \  |  |     |  |     ");
        // CentreText(@".----)   |    /  _____  \  |  |_)  |  /  _____  \ |  `----.|  `----.");
        // CentreText(@"|_______/    /__/     \__\ |______/  /__/     \__\ \______| \______|");
        CentreText(@" __     _    _       __   _______     _       __   _          _       ");
        CentreText(@" \ \   | |  | |_____/ /  / _____ \   | |_____/ /  | |        | |      ");
        CentreText(@"  \ \  | |  |________/  / /     \ \  |________/   | | _  _   | | _  _ ");
        CentreText(@"   \ \ | |   _________     =====      _________   |_||_|| |  |_||_|| |");
        CentreText(@"    \ \| |  | |_____ \  \ \_____/ /  | |_____ \         | |        | |");
        CentreText(@"==== \_| |  |_|     \_\  \_______/   |_|     \_\        |_|        |_|");



 

    




        Console.ResetColor();

        // Start the flashing text animation
        new Thread(() => FlashingTextAnimation("--- PRESS ANY KEY TO START ---", 20)).Start();

        // Get console input
        while (true)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey();
                animationPlaying = false;
                Console.Clear();
                
                // Start the game
                Game game = new Game();
                game.NewGame();
            }
        }
    }


    // Flashing text animation
    static void FlashingTextAnimation(string text, int cursorTop)
    {
        bool showText = true;
        while (animationPlaying == true)
        {
            // Change the colors depending on the state
            if (showText) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.DarkGray;

            // Write the text
            Console.SetCursorPosition(Console.CursorLeft, cursorTop);
            CentreText(text);
            Console.ResetColor();

            // Change the state of the text, then wait
            showText = !showText;
            Thread.Sleep(500); //? 500ms is 0.5 seconds            
        }
    }

    // Place text in the centre of the console
    static void CentreText(string text)
    {
        Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
        Console.WriteLine(text);
    }
}