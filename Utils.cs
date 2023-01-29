public class Utils
{

    // Place text in the centre of the console
    public static void CentreText(string text)
    {
        Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
        Console.WriteLine(text);
    }

}