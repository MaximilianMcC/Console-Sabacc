public class Player
{
    public string name { get; set; }
    public Queue<Card> hand;
}





public class Card
{
    public CardType cardType { get; set; }
    public int value { get; set; }
}


public enum CardType
{
    POSITIVE,
    NEGATIVE,
    ZERO
}