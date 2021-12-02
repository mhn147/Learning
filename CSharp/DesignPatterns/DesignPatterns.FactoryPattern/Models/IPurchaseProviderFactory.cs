using DesignPatterns.Business.Models.Commerce;
using DesignPatterns.Business.Models.Shipping;
using DesignPatterns.Business.Models.Shipping.Factories;
using DesignPatterns.FactoryPattern.Models.Commerce.Invoice;
using DesignPatterns.FactoryPattern.Models.Commerce.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Models
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }

    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider("Australia");
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }

    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice(); 
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider("Australia");
        }

        public ISummary CreateSummary(Order order)
        {
            return new EmailSummary();
        }
    }
}
