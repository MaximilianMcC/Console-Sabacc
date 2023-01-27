class Game
{
	List<Player> players = new List<Player>();
	Deck deck = new Deck();
	Deck drawPile = new Deck();
	Deck discardPile = new Deck();
	int round = 1;

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


		// Begin the first round
		Round();
	}


	// Game round
	void Round()
	{
		ArrowMenu menu = new ArrowMenu()
		{
			decorationCharacters = 4,
			padding = 5
		};


		// Loop through all of the different players
		foreach (Player player in players)
		{
			// Give a title showing the round, and player
			Console.Clear();
			Console.WriteLine($"Round {round}/3 -- {player.name}");


			// Print the players current cards
			Console.WriteLine("Your cards: ");
			foreach (Card card in player.hand.cards)
			{
				Console.Write(card.GetDisplayName() + "\t");
			}
			
			// Print the top card in the discard pile
			Console.WriteLine("\n Top card in the discard pile: " + discardPile.cards.First().GetDisplayName());


			// Show all of the availble moves
			menu.title = "Select a move from below";
			menu.menuItems = new[]
			{
				"Gain    | Pick up a card from the draw pile.",
				"Swap    | Swap a card in your hand for the top one in the discard pile.",
				"Stand   | Do nothing."
			};
			int move = menu.VerticalMenu();

			// Get the move, then do the move
			if (move == 0)
			{
				
				// Pick up a card
				player.hand.AddCard(drawPile.PickUpCard());

			}
			else if (move == 1)
			{
				// Show the cards that can be swapped
				menu.title = "Select a card from below to swap with";
				menu.menuItems = player.hand.cards.Select(card => card.GetDisplayName()).ToArray();
				Card cardToSwap = player.hand.GetCardFromIndex(menu.VerticalMenu());

				// Move the top card from the discard pile to the players hand
				player.hand.AddCard(discardPile.cards.First());

				// Move the card from the players hand to the discard pile, then remove it from the players hand
				discardPile.AddCard(cardToSwap);
				player.hand.RemoveCard(cardToSwap);
			}
			//? There is nothing for the 3rd move, because it is do nothing.


			//TODO: Don't repeat all this code
			// Print the players new current cards
			Console.WriteLine("Your new cards: ");
			foreach (Card card in player.hand.cards)
			{
				Console.Write(card.GetDisplayName() + "\t");
			}
			
			// Print the top card in the discard pile
			Console.WriteLine("\n New top card in the discard pile: " + discardPile.cards.First().GetDisplayName());


			// Ask them to end turn
			Console.WriteLine("Press any key to end your current turn");
			Console.ReadKey();
		}



		// At the end of the round throw the spike dice. If both values match all players get new cards
		Random random = new Random();
		if (random.Next(1, 6) == random.Next(1, 6))
		{
			// Sabacc Shift
			Console.WriteLine("Sabacc shift! All players get a new hand equal to the count of their current cards");

			// Loop through all players
			foreach (Player player in players)
			{
				// Remove all of their cards and add them to the discard pile
				int currentPlayersCardCount = player.hand.cards.Count;
				for (int i = 0; i < currentPlayersCardCount; i++) discardPile.AddCard(player.hand.GetCardFromIndex(i));

				// Give back new cards from the draw pile
				for (int i = 0; i < currentPlayersCardCount; i++) player.hand.AddCard(drawPile.PickUpCard());
			}
		}
		else Console.WriteLine("No shift....");



		Console.WriteLine("Press any key to move onto the next round");
		Console.ReadKey();

		
		// Start the next round, or end the game
		if (round == 3) EndGame();
		else
		{
			round++;
			Round();
		}

	}


	// End of the game
	void EndGame()
	{
		// Check for who wins
	}

}