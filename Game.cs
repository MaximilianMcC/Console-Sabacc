class Game
{
    public int round { get; set; }
    public List<Player> players { get; set; }




    public void Start()
    {
        Utils.Header("new game");

        // Ask how many players
        int playersInput = 2;
        while (true)
        {
            // Ask for how many players and check for if they put in more or less
            Console.Write("How many players (2-8)  ->");
            playersInput = int.Parse(Console.ReadLine().Trim());
            if (playersInput > 8 || playersInput < 2) Console.WriteLine("You can only have 2-8 players!\n");
            else break;
        }

        
        // Add each of the players
        for (int i = 0; i < playersInput; i++)
        {
            // Get their name
            Console.Write($"Player {i + 1}'s name   ->");
            string currentName = Console.ReadLine().Trim();
            
            // Give them 2 random cards
        }


    }

    public void Round()
    {
        Utils.Header("round");
    }

    public void End()
    {
        Utils.Header("end of game");
    }

}