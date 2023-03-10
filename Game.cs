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
			// Show the player the current game state
			ShowGameState(player);

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


			// Show the player the new game state
			ShowGameState(player);

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
				player.hand.cards.Clear();

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
		// Get the player with the closest score to 0
		//TODO: Use the correct sabacc scoring system.
		Player winner = players.MinBy(player => Math.Abs(player.hand.GetTotal()));

		Console.Clear();
		Console.WriteLine("winner: " + winner.name);
		Console.ReadKey();
	}










	// Display the game state for a player
	void ShowGameState(Player player)
	{
		// Clear the screen to remove all other game stuff
		Console.Clear();


		// Get the total score as a string that includes the sign
		//TODO: Figure out what this conditional formatting is doing
		string totalScore = player.hand.GetTotal().ToString("+#;-#;0");

		// Used to add characters to the gui thing
		string space = "";

		Console.WriteLine('???' + new string('???', Console.WindowWidth - 3) + '???');
		Console.WriteLine('???' + new string('???', Console.WindowWidth - 3) + '???');
		Console.WriteLine('???' + new string('???', Console.WindowWidth - 3) + '???');


		// Display the total score
		//TODO: Change the color of the score depending on what it is
		Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
		if (totalScore.Length == 1) space = "  ";
		else if (totalScore.Length == 2) space = " ";
		else if (totalScore.Length == 3) space = "";
		Console.WriteLine("????????????????????????????????????????????????????????????");
		Console.WriteLine($"??? Total score: {totalScore}{space} ???");
		Console.WriteLine("????????????????????????????????????????????????????????????");



		// Display the current round
		Console.SetCursorPosition((Console.WindowWidth - 15), Console.CursorTop - 3);
		Console.WriteLine("??????????????????????????????????????????");
		Console.SetCursorPosition((Console.WindowWidth - 15), Console.CursorTop);
		Console.WriteLine($"??? Round: {round}/3 ???");
		Console.SetCursorPosition((Console.WindowWidth - 15), Console.CursorTop);
		Console.WriteLine("??????????????????????????????????????????");



		// display the players name
		Console.SetCursorPosition((Console.WindowWidth - (player.name.Length + (5 + 13))), Console.CursorTop - 3);
		space = new string('???', (player.name.Length + 2));
		Console.WriteLine($"???{space}");
		Console.SetCursorPosition((Console.WindowWidth - (player.name.Length + (5 + 13))), Console.CursorTop);
		Console.WriteLine($"??? {player.name} ");
		Console.SetCursorPosition((Console.WindowWidth - (player.name.Length + (5 + 13))), Console.CursorTop);
		Console.WriteLine($"???{space}");


		// Draw the box where all of the cards go
		//TODO: Draw the discard pile box using set cursor position
		Console.WriteLine();
		Console.WriteLine(@"???????????? Your hand ?????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????       ???????????? discard pile ????????????");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"???                                                                                        ???       ???                    ???");
		Console.WriteLine(@"??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????       ??????????????????????????????????????????????????????????????????");
		
		// Draw all of the cards in the players hand
		int initialCardPosition = 4;
		int cardPositionMultiplier = 17;
		for (int i = 0; i < player.hand.cards.Count; i++)
		{
			//? 7 starting from 0
			Card card = player.hand.cards.ElementAt(i);
			card.DrawAsciiCard((initialCardPosition + (i * cardPositionMultiplier)), 7);
		}

		// Draw the top card in the discard pile
		Card discard = discardPile.cards.First();
		discard.DrawAsciiCard(101, 7);

		// Return the cursor to the bottom of everything
		Console.SetCursorPosition(0, 20);
	}

}