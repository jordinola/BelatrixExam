using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Invoice.Requests;
using Belatrix.Exam.WebApi.ViewModels.Invoice.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoicePostRequest, Invoice>();
            CreateMap<InvoicePutRequest, Invoice>();

            CreateMap<Invoice, InvoiceResponse>();
        }
    }
}