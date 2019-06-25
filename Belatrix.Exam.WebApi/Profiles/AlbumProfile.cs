using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Requests.Album;
using Belatrix.Exam.WebApi.Responses.Album;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<AlbumPostRequest, Album>();
            CreateMap<AlbumPutRequest, Album>();

            CreateMap<Album, AlbumResponse>();
        }
    }
}
