namespace DesignPatterns.SingletonPattern;

public sealed class ThreadSafeWithLocksSingleton
{
    private static ThreadSafeWithLocksSingleton _instance;
    private static readonly object padlock = new object();

    public static ThreadSafeWithLocksSingleton Instance
    {
        get
        {
            Console.WriteLine("Instance called.");
            
            // lock (padlock) // this lock is used on *every* reference to Singeleton
            // {
            //     if (_instance == null)
            //     {
            //         _instance = new ThreadSafeWithLocksSingleton();
            //     }
            //
            //     return _instance;
            // }

            // Better locking, only locks if the instance is null
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeWithLocksSingleton();
                    }   
                }
            }

            return _instance;
        }
    }

    private ThreadSafeWithLocksSingleton()
    {
        //...
        Console.WriteLine("Constructor invoked.");
    }
}