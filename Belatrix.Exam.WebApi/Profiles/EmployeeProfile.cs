using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Employee.Requests;
using Belatrix.Exam.WebApi.ViewModels.Employee.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeePostRequest, Employee>();
            CreateMap<EmployeePutRequest, Employee>();

            CreateMap<Employee, EmployeeResponse>();
        }
    }
}