using DesignPatterns.Business.Models.Commerce;
using DesignPatterns.Business.Models.Shipping.Factories;
using DesignPatterns.FactoryPattern;
using DesignPatterns.FactoryPattern.Models;
using System;

namespace DesignPatterns.ConsoleApp;

public class Program
{
    //Before
    public static void Main(string[] args)
    {
        #region Create Order
        Console.Write("Recipient Country: ");
        var recipientCountry = Console.ReadLine().Trim();

        Console.Write("Sender Country: ");
        var senderCountry = Console.ReadLine().Trim();

        Console.Write("Total Order Weight: ");
        var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

        var order = new Order
        {
            Recipient = new Address
            {
                To = "Filip Ekberg",
                Country = recipientCountry
            },

            Sender = new Address
            {
                To = "Someone else",
                Country = senderCountry
            },

            TotalWeight = totalWeight
        };

        order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
        order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
        #endregion

        IPurchaseProviderFactory purchaseProviderFactory;

        var factoryProvider = new PurchaseProviderFactoryProvider();

        purchaseProviderFactory = factoryProvider.CreateFactoryFor(order.Sender.Country);

        if (purchaseProviderFactory == null)
        {
            throw new ArgumentException("Sender Country has no purchase provider.");
        }

        var cart = new ShoppingCart(order, purchaseProviderFactory);

        var shippingLabel = cart.Finalize();

        Console.WriteLine(shippingLabel);
    }
}
