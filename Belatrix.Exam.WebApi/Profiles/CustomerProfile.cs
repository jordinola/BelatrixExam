using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Customer.Requests;
using Belatrix.Exam.WebApi.ViewModels.Customer.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerPostRequest, Customer>();
            CreateMap<CustomerPutRequest, Customer>();

            CreateMap<Customer, CustomerResponse>();
        }
    }
}