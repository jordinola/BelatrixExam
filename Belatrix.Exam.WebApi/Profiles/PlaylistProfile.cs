using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Playlist.Requests;
using Belatrix.Exam.WebApi.ViewModels.Playlist.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<PlaylistPostRequest, Playlist>();
            CreateMap<PlaylistPutRequest, Playlist>();

            CreateMap<Playlist, PlaylistResponse>();
        }
    }
}