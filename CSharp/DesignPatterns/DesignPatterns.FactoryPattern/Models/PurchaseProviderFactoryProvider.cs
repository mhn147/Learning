using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Models
{
    public class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> _factories;

        public PurchaseProviderFactoryProvider()
        {
            _factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderFactory).IsAssignableFrom(t));
        }

        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = _factories.Single(x =>
                x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            return (IPurchaseProviderFactory)Activator.CreateInstance(factory);
        }
    }
}
