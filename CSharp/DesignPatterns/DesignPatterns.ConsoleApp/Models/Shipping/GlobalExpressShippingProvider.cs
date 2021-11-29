using DesignPatterns.Business.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return $"GLOBAL_EXPRESS-{Guid.NewGuid()}";
        }
    }
}
