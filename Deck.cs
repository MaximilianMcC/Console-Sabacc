public class Card
{
    public CardType cardType { get; set; }
    public int value { get; set; }

    public string GetDisplayName()
    {
        return (char)cardType + value.ToString();
    }
}


public enum CardType
{
    POSITIVE = '+',
    NEGATIVE = '-',
    ZERO = ' '
}


public class Deck
{
    public LinkedList<Card> cards { get; set; }

    // Add a card to the deck
    public void AddCard(Card card)
    {
        cards.AddFirst(card);
    }

    // Remove the top card from the deck
    public Card PickUpCard()
    {
        // Make a copy of the card, then delete the original
        Card cardToPickup = cards.First();
        cards.RemoveFirst();

        // Return the card copy
        return cardToPickup;
    }
}