namespace DesignPatterns.SingletonPattern;

public class LazyTSingleton
{
    private static readonly Lazy<LazyTSingleton> _lazy = new Lazy<LazyTSingleton>(
        () => new LazyTSingleton());

    public static LazyTSingleton Instance
    {
        get => _lazy.Value;
    }

    private LazyTSingleton()
    {
        
    }
}