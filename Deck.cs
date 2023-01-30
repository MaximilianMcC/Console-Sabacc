public enum CardType
{
    POSITIVE = '+',
    NEGATIVE = '-',
    ZERO = ' '
}


public class Card
{
    public CardType cardType { get; set; }
    public int value { get; set; }

    public string GetDisplayName()
    {
        return (char)cardType + value.ToString();
    }

    public void DrawAsciiCard()
    {
        //TODO: Find a way to remove the "Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);" spam

        int startCursorTop = Console.CursorTop;
        int startCursorLeft = Console.CursorLeft;
        int cardWidth = 14;

        // Draw the very top part of the card
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"    ______    ");

        // Draw the top line that states the card type
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.Write(@"   /");
        if (cardType == CardType.POSITIVE) Console.ForegroundColor = ConsoleColor.Green;
        else if (cardType == CardType.NEGATIVE) Console.ForegroundColor = ConsoleColor.Red;
        else if (cardType == CardType.ZERO) Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(@"======");
        Console.ResetColor();
        Console.WriteLine(@"\   ");

        // Draw the rest of the top of the card
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"  /        \  ");
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@" /          \ ");
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"|            |");

        // Draw the middle part of the card
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.Write(@"|     " + (char)cardType);
        if (value.ToString().Length == 1) Console.WriteLine(value + "     |");
        else if (value.ToString().Length == 2) Console.WriteLine(value + "    |");

        // Draw the bottom part of the card
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"|            |");
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@" \          / ");
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"  \        /  ");
        Console.SetCursorPosition((startCursorLeft + cardWidth), Console.CursorTop);
        Console.WriteLine(@"   \______/   ");

        // Move the cursor over to the end of the card
        Console.SetCursorPosition((startCursorLeft + cardWidth), startCursorTop);
    }
}




public class Deck
{
    public LinkedList<Card> cards { get; set; }

    public Deck()
    {
        // Make a new empty list of cards when a deck is created
        cards = new LinkedList<Card>();
    }

    // Add a card to the deck
    public void AddCard(Card card)
    {
        cards.AddFirst(card);
    }

    // Get a card from its index
    public Card GetCardFromIndex(int index)
    {
        return cards.ElementAt(index);
    }

    // Remove a card at its index
    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    // Remove the top card from the deck then return it
    public Card PickUpCard()
    {
        // Make a copy of the card, then delete the original
        Card cardToPickup = cards.First();
        cards.RemoveFirst();

        // Return the card copy
        return cardToPickup;
    }

    // Get the sum of all of the cards in the deck
    public int GetTotal()
    {
        int total = 0;
        foreach (Card card in cards)
        {
            if (card.cardType == CardType.POSITIVE) total += card.value;
            else if (card.cardType == CardType.NEGATIVE) total -= card.value;
        }

        return total;
    }
}