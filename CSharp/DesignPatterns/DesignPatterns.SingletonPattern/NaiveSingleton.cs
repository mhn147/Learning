namespace DesignPatterns.SingletonPattern;

public sealed class NaiveSingleton
{
    private static NaiveSingleton _instance;

    public static NaiveSingleton Instance
    {
        get
        {
            Console.WriteLine("Instance called.");
            if (_instance == null)
            {
                _instance = new NaiveSingleton();
            }

            return _instance;
        }
    }

    private NaiveSingleton()
    {
        //...
        Console.WriteLine("Constructor invoked.");
    }
}