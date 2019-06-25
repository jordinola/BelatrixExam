using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Album.Requests;
using Belatrix.Exam.WebApi.ViewModels.Album.Responses;

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
