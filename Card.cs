class Card
{
    //TODO: Make type an enum instead of char
    public CardType type { get; set; }
    public int value { get; set; }

    // Get the cards display name
    public string displayName()
    {
        return (char) type + value.ToString();
    }
}


enum CardType
{
    POSITIVE = '+',
    NEGATIVE = '-',
    ZERO = '\0'
}