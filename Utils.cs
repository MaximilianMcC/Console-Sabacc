class Utils
{
    
    // Print a header with borders and stuff
    public static void Header(string headerText)
    {
        int length = 34;

        Console.WriteLine("\n" + new String('-', length));
        Console.WriteLine(new String(' ', (length - headerText.Length) / 2) + headerText.ToUpper());
        Console.WriteLine(new String('-', length) + "\n");
    }


    // Get a random card
    public static Card getRandomCard()
    {
        Random random = new Random();
        char type;
        if (random.NextSingle())


        //TODO: Check for if the card is already in the deck or something
        Card card = new Card()
        {
            type = type,
            value = value
        };

        return card;
    }

}