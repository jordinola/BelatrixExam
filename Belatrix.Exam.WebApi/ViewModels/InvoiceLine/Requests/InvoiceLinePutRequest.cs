using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Requests
{
    public class InvoiceLinePutRequest
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
