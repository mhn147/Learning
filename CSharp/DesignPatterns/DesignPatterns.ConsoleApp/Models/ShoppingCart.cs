using DesignPatterns.Business.Models.Commerce;
using DesignPatterns.Business.Models.Shipping;
using DesignPatterns.Business.Models.Shipping.Factories;
using DesignPatterns.FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Before;

public class ShoppingCart
{
    private readonly Order order;
    private readonly IPurchaseProviderFactory purchaseProviderFactory;

    public ShoppingCart(Order order,
        IPurchaseProviderFactory purchaseProviderFactory)
    {
        this.order = order;
        this.purchaseProviderFactory = purchaseProviderFactory;
    }

    public string Finalize()
    {
        var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);

        // Send invoice..

        var summary = purchaseProviderFactory.CreateSummary(order);
        summary.Send();

        order.ShippingStatus = ShippingStatus.ReadyForShippment;

        return shippingProvider.GenerateShippingLabelFor(order);
    }
}

