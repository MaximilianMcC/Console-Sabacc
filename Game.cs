class Game
{
	List<Player> players = new List<Player>();
	Deck deck = new Deck();
	Deck drawPile = new Deck();
	Deck discardPile = new Deck();

	// Create a new game, and setup everything
	public void NewGame()
	{
		// Generate the deck of cards for the current game
		//? Deck consists of 60 cards from 1-10, and 2 cards with a value of 0 (Sylops). Total is 62

		// Add 3 sets of 10 positive cards
		for (int i = 0; i < 3; i++)
		{
			for (int j = 1; j < 11; j++)
			{
				// Generate the card
				Card card = new Card();
				card.cardType = CardType.POSITIVE;
				card.value = j;

				// Add the card to the deck
				deck.AddCard(card);
			}
		}

		// Add 3 sets of 10 negative cards
		for (int i = 0; i < 3; i++)
		{
			for (int j = 1; j < 11; j++)
			{
				// Generate the card
				Card card = new Card();
				card.cardType = CardType.NEGATIVE;
				card.value = j;

				// Add the card to the deck
				deck.AddCard(card);
			}
		}

		// Add 2 zero cards
		deck.AddCard(new Card() { cardType = CardType.ZERO, value = 0 });
		deck.AddCard(new Card() { cardType = CardType.ZERO, value = 0 });


		// Shuffle the deck, then create the draw pile
		Random random = new Random();
		List<Card> shuffledDeck = deck.cards.OrderBy(card => random.Next()).ToList();
		drawPile.cards = new LinkedList<Card>(shuffledDeck);


		// Make the discard pile from the deck
		discardPile.AddCard(drawPile.PickUpCard());






		// Add all of the players
		Console.WriteLine("How many players? (2 - 8)");
		int playerCount = int.Parse(Console.ReadLine().Trim());

		for (int i = 0; i < playerCount; i++)
		{
			Player player = new Player();

			// Get the players name
			Console.Write("Player " + (i + 1) + "'s name: ");
			string playerName = Console.ReadLine().Trim();
			player.name = playerName;

			// Give them two starting cards from the draw pile
			player.hand.AddCard(drawPile.PickUpCard());
			player.hand.AddCard(drawPile.PickUpCard());

			// Add the player to the list of players
			players.Add(player);
		}
	}
}