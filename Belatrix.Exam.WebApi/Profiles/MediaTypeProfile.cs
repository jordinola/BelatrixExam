using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.MediaType.Requests;
using Belatrix.Exam.WebApi.ViewModels.MediaType.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class MediaTypeProfile : Profile
    {
        public MediaTypeProfile()
        {
            CreateMap<MediaTypePostRequest, MediaType>();
            CreateMap<MediaTypePutRequest, MediaType>();

            CreateMap<MediaType, MediaTypeResponse>();
        }
    }
}