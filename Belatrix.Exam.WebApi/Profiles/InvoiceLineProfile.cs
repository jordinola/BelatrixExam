using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Requests;
using Belatrix.Exam.WebApi.ViewModels.InvoiceLine.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class InvoiceLineProfile : Profile
    {
        public InvoiceLineProfile()
        {
            CreateMap<InvoiceLinePostRequest, InvoiceLine>();
            CreateMap<InvoiceLinePutRequest, InvoiceLine>();

            CreateMap<InvoiceLine, InvoiceLineResponse>();
        }
    }
}