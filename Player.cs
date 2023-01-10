class Player
{
    public string name { get; set; }
    public List<Card> hand { get; set; }

    // Calculate the total score of the players hand
    public int getScore()
    {
        int score = 0;
        foreach (Card card in hand)
        {
            // Add or remove score depending on the card type
            //? Nothing needs to be done if its zero
            if (card.type == CardType.POSITIVE) score += card.value;
            else if (card.type == CardType.NEGATIVE) score -= card.value;
        }

        // Give back the final score
        return score;
    }

    // Pick up a card
    public List<Card> PickUp(List<Card> cardPile)
    {
        hand.Add(cardPile[1]);
        cardPile.RemoveAt(1);

        // Return the new card pile list
        return cardPile;
    }
}