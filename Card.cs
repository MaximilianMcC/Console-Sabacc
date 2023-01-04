class Card
{
    //TODO: Make type an enum instead of char
    public char type { get; set; }
    public int value { get; set; }

    // Get the cards display name
    public string displayName()
    {
        // Check for if it's 0
        if (type == '0') return "0";
        return type + value.ToString();
    }
}


/*
    type = '+';
    value = 3;

    type = '-';
    value = 7;

    type = '0';
    value = 0;
*/