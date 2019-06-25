using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.PlaylistTrack.Requests;
using Belatrix.Exam.WebApi.ViewModels.PlaylistTrack.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class PlaylistTrackProfile : Profile
    {
        public PlaylistTrackProfile()
        {
            CreateMap<PlaylistTrackPostRequest, PlaylistTrack>();
            CreateMap<PlaylistTrackPutRequest, PlaylistTrack>();

            CreateMap<PlaylistTrack, PlaylistTrackResponse>();
        }
    }
}