
/// <summary>
/// This class contains helper methods for reading simple data input from the Console.
/// The data input can represent either a string or an int
/// </summary>
public class UserInputReader
{
    public static string ReadStringFromUser(string prompt, string valueIfBlank = "")
    {
        string value = ReadInputFromUser(prompt);

        return string.IsNullOrEmpty(value) ? valueIfBlank : value;
    }

    public static int ReadIntFromUser(string prompt, int valueIfBlank = 0)
    {
        string input = ReadInputFromUser(prompt);
        if (string.IsNullOrEmpty(input))
            return valueIfBlank;

        bool isAnInt = Int32.TryParse(input, out int value);

        if (isAnInt)
            return value;
        else
        {
            Console.WriteLine($"{input} is not a numeric value, please try again...");
            return ReadIntFromUser(prompt, valueIfBlank);
        }
    }

    /// <summary>
    /// Prompts the user with the provided prompt, 
    /// and reads the input from the Console.
    /// </summary>
    private static string ReadInputFromUser(string prompt)
    {
        Console.WriteLine();
        Console.Write($"{prompt} : ");

        string input = Console.ReadLine() ?? "";

        return input;
    }
}
