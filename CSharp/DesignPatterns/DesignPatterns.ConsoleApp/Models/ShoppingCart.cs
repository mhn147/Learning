﻿using DesignPatterns.Business.Models.Commerce;
using DesignPatterns.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Before;

public class ShoppingCart
{
    private readonly Order order;

    public ShoppingCart(Order order)
    {
        this.order = order;
    }

    public string Finalize()
    {
        var shippingProvider = ShippingProviderFactory.CreateShippingProvider(order.Sender.Country);

        order.ShippingStatus = ShippingStatus.ReadyForShippment;

        return shippingProvider.GenerateShippingLabelFor(order);
    }
}

