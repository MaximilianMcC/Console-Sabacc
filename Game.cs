class Game
{
    int round { get; set; }
    List<Player> players { get; set; }
    List<Card> deck { get; set; }
    List<Card> drawPile { get; set; }
    List<Card> discardPile { get; set; }



    public void Start()
    {
        Utils.Header("new game");


        // Generate all of the cards
        deck = new List<Card>();
        discardPile = new List<Card>();

        // Add the 2 sylops
        deck.Add(new Card() { type = '0', value = 0 });
        deck.Add(new Card() { type = '0', value = 0 });

        //TODO: Don't use 4 for loops!!1!
        // Positive cards
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                // Make the card
                Card currentCard = new Card();
                currentCard.type = '+';
                currentCard.value = j;

                // Add it to the deck
                deck.Add(currentCard);
            }
        }

        // Negative cards
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                // Make the card
                Card currentCard = new Card();
                currentCard.type = '-';
                currentCard.value = j;

                // Add it to the deck
                deck.Add(currentCard);
            }
        }

        // Shuffle the deck
        //! idk what this is doing!!!!!!
        Random random = new Random();
        deck = deck.OrderBy(item => random.Next()).ToList();

        // Make the discard pile
        discardPile.Add(deck[1]);
        deck.RemoveAt(1);


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