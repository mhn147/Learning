using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Business.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string Country);

        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);

            // Extra logic, optional
            if (country == "Sweden" && provider.InsuranceOptions.ProviderHasExtendedInsurance)
            {
                provider.RequireSignature = false;
            }

            return provider;
        }
    }
}
