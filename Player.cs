public class Player
{
    public string name { get; set; }
    public Deck hand { get; set; }

    public Player()
    {
        hand = new Deck();
    }
}
