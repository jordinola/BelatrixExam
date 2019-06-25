using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Requests;
using Belatrix.Exam.WebApi.ViewModels;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<AlbumRequest, Album>();

            CreateMap<Album, AlbumResponse>();
        }
    }
}
