using DesignPatterns.FactoryPattern;
using DesignPatterns.FactoryPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatterns.FactoryPattern.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FinalizeOrderWithoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var cart = new ShoppingCart(order, null);

            cart.Finalize();
        }

        [TestMethod]
        public void FinalizeOrderWithSwedenPurchaseProvider_GeneratesShippingLabel()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var purchaseProviderFactory = new SwedenPurchaseProviderFactory();

            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }
    }
}