using System;

public class Program
{
    public static void Main(string[] args)
    {
        int? a = 28;
        int b = a ?? -1;
        Console.WriteLine($"b is {b}");  // output: b is 28

        int? c = null;
        int d = c ?? -1;
        Console.WriteLine($"d is {d}");  // output: d is -1
    }

    private static void NullableVariableTypes()
    {
        // Nullable Reference Types

        string userInput = string.Empty;
        double? balance;

        while (true && !string.Equals(userInput, "q", StringComparison.InvariantCultureIgnoreCase))
        {
            Console.Write("Do you want to enter you balance? (n/y) ");

            userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userInput)
                && !string.Equals(userInput, "n", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Balance: ");
                userInput = Console.ReadLine();
                balance = double.Parse(userInput);
            }
            else
            {
                balance = null;
            }

            if (balance.HasValue)
            {
                Console.WriteLine($"Your balance is: {balance}");
            }
            else
            {
                Console.WriteLine($"No balance provided.");
            }

            Console.WriteLine("Press 'q' to quit.");
            userInput = Console.ReadLine();
        }
    }
}
