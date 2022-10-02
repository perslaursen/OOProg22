// NB: This class is only used for solving step 5 and 6
public class RandomNumberGenerator
{
    private static Random _random = new Random();

    public static int Generate(int minimum, int maximum)
    {
        return _random.Next(minimum, maximum + 1);
    }
}
