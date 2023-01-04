class Game
{
    int round = 1;
    List<Player> players = new List<Player>();
    List<Card> deck = new List<Card>();
    List<Card> drawPile = new List<Card>();
    List<Card> discardPile = new List<Card>();



    public void Start()
    {
        Utils.Header("new game");


        // Generate all of the cards
        deck.Add(new Card() { type = '0', value = 0 });
        deck.Add(new Card() { type = '0', value = 0 });

        // Add all of the other cards
        //? 60 cards + 2 sylops = 62 total cards
        for (int i = 0; i < 6; i++)
        {
            char type = '+';
            if (i > 3) type = '-';

            for (int j = 1; j < 11; j++)
            {
                // Make the card
                Card currentCard = new Card();
                currentCard.type = type;
                currentCard.value = j;

                // Add it to the deck
                deck.Add(currentCard);
            }
        }

        // Shuffle the deck
        //? idk what this is doing!!!!!!
        Random random = new Random();
        deck = deck.OrderBy(item => random.Next()).ToList();

        // Make the draw pile
        drawPile = deck;

        // Make the discard pile
        discardPile.Add(deck[1]);
        drawPile.RemoveAt(1);


        // Ask how many players
        int playerCount = 2;
        while (true)
        {
            // Ask for how many players and check for if they put in more or less
            //TODO: TryPass
            Console.Write("How many players (2-8):");
            playerCount = int.Parse(Console.ReadLine().Trim());
            if (playerCount > 8 || playerCount < 2) Console.WriteLine("You can only have 2-8 players!\n");
            else break;
        }

        
        // Add all of the players
        for (int i = 0; i < playerCount; i++)
        {
            Player currentPlayer = new Player();

            // Get the current players game
            Console.Write($"Player {i + 1}'s name: ");
            currentPlayer.name = Console.ReadLine().Trim();

            // Give the player two random starting cards
            currentPlayer.hand = new List<Card>();
            currentPlayer.hand = PickUp(currentPlayer.hand);
            currentPlayer.hand = PickUp(currentPlayer.hand);

            // Add the player to the list
            players.Add(currentPlayer);
        }


        // Begin the first round
        Round();
    }

    public void Round()
    {
        Utils.Header("round " + round);
        round++;


        // Loop through all of the players and let them do their turn
        foreach (Player player in players)
        {
            // Give some text and stuff
            Console.WriteLine($"----- {player.name}'s turn -----");
            Console.WriteLine("You have got three options:");

            //TODO: Make fancy arrow menu
            //TODO: Make arrow menu a legit package nugget or something idk github repo
            Console.WriteLine("| 1 | Draw  | Get a new card from the deck                  |");
            Console.WriteLine("| 2 | Swap  | Swap a card with the card on the discard pile |");
            Console.WriteLine("| 3 | Stand | Do nothing                                    |");

            // Get input
            ConsoleKeyInfo selection = Console.ReadKey(true);
            if (selection.Key == ConsoleKey.D1)
            {
                // Draw
                player.hand = PickUp(player.hand);

            }
            else if (selection.Key == ConsoleKey.D2)
            {
                // Swap
                
            }
            else if (selection.Key == ConsoleKey.D3)
            {
                // Stand
            }

        }
    }

    public void End()
    {
        Utils.Header("end of game");

        //TODO: Reset variables at top of file
    }









    //TODO: Put in Player class
    List<Card> PickUp(List<Card> hand)
    {
        hand.Add(deck[1]);
        drawPile.RemoveAt(1);

        return hand;
    }

}
