using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.Invoice.Responses
{
    public class InvoiceResponse
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }
    }
}
