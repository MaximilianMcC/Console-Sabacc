public class Game
{

    // Variables
    int round = 1;
    List<Player> players = new List<Player>();
    List<Card> deck = new List<Card>();
    List<Card> drawPile = new List<Card>();
    List<Card> discardPile = new List<Card>();



    public void Start()
    {
        Utils.Header("new game");


        // Generate all of the cards
        deck.Add(new Card() { type = CardType.ZERO, value = 0 });
        deck.Add(new Card() { type = CardType.ZERO, value = 0 });

        // Add all of the other cards
        //? 60 cards + 2 sylops = 62 total cards
        for (int i = 0; i < 6; i++)
        {
            CardType type = CardType.POSITIVE;
            if (i > 3) type = CardType.NEGATIVE;

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
            drawPile = currentPlayer.PickUp(drawPile);
            drawPile = currentPlayer.PickUp(drawPile);

            // Add the player to the list
            players.Add(currentPlayer);
        }


        // Begin the first round
        Round();
    }

    public void Round()
    {
        Utils.Header("round " + round);

        // Check for what round it is
        if (round != 4) round++;
        else {
            Console.WriteLine("end of gmae...");
        }


        // Loop through all of the players and let them do their turn
        foreach (Player player in players)
        {
            List<Card> hand = player.hand;

            
            // Show all of the players cards
            Console.WriteLine("Your current hand:");
            foreach (Card card in hand)
            {
                Console.Write(card.displayName() + "\t");
            }


            // Make an arrow menu with all of the moves availble
            ArrowMenu menu = new ArrowMenu()
            {
                title = "Select an option from below",
                menuItems = new string[]
                {
                    "Draw  | Pick up a new card from the draw pile.",
                    "Swap  | Swap a card in your hand with the top card on the discard pile.",
                    "Stand | Do nothing."
                },
                padding = 5,
                decorationCharacters = 4
            };
            

            // Get their move
            int move = menu.VerticalMenu();
            if (move == 0)
            {
                // Draw
                Console.WriteLine("Draw");
            }
            else if (move == 1)
            {
                // Swap
                Console.WriteLine("Swap");
            }
            else if (move == 2)
            {
                // Stand
                Console.WriteLine("Stand");
            }
            

        }



        // Roll the spike dice
        Random random = new Random();
        int dice1 = random.Next(1, 6);
        int dice2 = random.Next(1, 6);

        Console.WriteLine("First spike dice: " + dice1);
        Console.WriteLine("Second spike dice: " + dice2);

        // Check for if there is a shift
        if (dice1 == dice2)
        {
            // Shift
            Console.WriteLine("Shift");
        }
        else Console.WriteLine("No shift");

        

        // Go to the next round
        Round();
    }

    public void End()
    {
        Utils.Header("end of game");

        //TODO: Reset variables at top of file
    }
}
