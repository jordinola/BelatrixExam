using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Genre.Requests;
using Belatrix.Exam.WebApi.ViewModels.Genre.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenrePostRequest, Genre>();
            CreateMap<GenrePutRequest, Genre>();

            CreateMap<Genre, GenreResponse>();
        }
    }
}