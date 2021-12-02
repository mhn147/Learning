namespace DesignPatterns.Business.Models.Shipping.Factories
{
    public class GlobalExpressShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string Country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}
