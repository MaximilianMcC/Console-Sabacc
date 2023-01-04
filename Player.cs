class Player
{
    public string name { get; set; }
    public List<Card> hand { get; set; }

    // Calculate the total score of the players hand
    int getScore()
    {
        int score = 0;
        foreach (Card card in hand)
        {
            // Add or remove score depending on the card type
            if (card.type == '+') score += card.value;
            else if (card.type == '-') score -= card.value;
        }

        // Give back the final score
        return score;
    }

    // Pick up a card
}