namespace DesignPatterns.SingletonPattern;

public sealed class StaticConstructorSingleton
{
    private static StaticConstructorSingleton _instance = new StaticConstructorSingleton();

    public static readonly string GREETING = "Hi!";

    //Explicit static constructor - for the beforeinit issue
    //https://csharpindepth.com/articles/singleton#dcl
    static StaticConstructorSingleton()
    {
        
    }
    
    public static StaticConstructorSingleton Instance
    {
        get
        {
            return _instance;
        }
    }

    private StaticConstructorSingleton()
    {
        //...
        Console.WriteLine("Constructor invoked.");
    }
}