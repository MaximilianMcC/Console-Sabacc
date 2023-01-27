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
}