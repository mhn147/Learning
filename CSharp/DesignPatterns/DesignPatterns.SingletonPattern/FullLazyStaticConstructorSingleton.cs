namespace DesignPatterns.SingletonPattern;

public sealed class FullLazyStaticConstructorSingleton
{
    public static readonly string GREETING = "Hi!";

    //Explicit static constructor - for the beforeinit issue
    //https://csharpindepth.com/articles/singleton#dcl
    static FullLazyStaticConstructorSingleton()
    {
        
    }
    
    public static FullLazyStaticConstructorSingleton Instance
    {
        get
        {
            return Nested._instance;
        }
    }

    private class Nested
    {
        static Nested() {}

        internal static readonly FullLazyStaticConstructorSingleton _instance = new FullLazyStaticConstructorSingleton();
    }
    
    private FullLazyStaticConstructorSingleton()
    {
        //...
        Console.WriteLine("Constructor invoked.");
    }
}