using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryPattern.Models.Commerce
{
    public interface IInvoice
    {
        public byte[] GenerateInvoice();
    }

    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world GST Invoice");
        }
    }

    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world VAT Invoice");
        }
    }

    public class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world NoVAT Invoice");
        }
    }
}
