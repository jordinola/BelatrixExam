using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Track.Requests;
using Belatrix.Exam.WebApi.ViewModels.Track.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            CreateMap<TrackPostRequest, Track>();
            CreateMap<TrackPutRequest, Track>();

            CreateMap<Track, TrackResponse>();
        }
    }
}