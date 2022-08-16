
public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public void Purr()
    {
        Console.WriteLine("*Cat purrs...");
    }

    public override string Sound()
    {
        return "Meow";
    }
}
