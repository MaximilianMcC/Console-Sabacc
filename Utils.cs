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


    public static void DebugMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}