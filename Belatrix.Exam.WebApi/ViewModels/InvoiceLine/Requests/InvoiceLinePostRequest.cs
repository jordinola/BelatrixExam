using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Requests
{
    public class InvoiceLinePostRequest
    {
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
