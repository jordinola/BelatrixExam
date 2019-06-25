using AutoMapper;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.ViewModels.Artist.Requests;
using Belatrix.Exam.WebApi.ViewModels.Artist.Responses;

namespace Belatrix.Exam.WebApi.Profiles
{
    public class ArtistProfile :  Profile
    {
        public ArtistProfile()
        {
            CreateMap<ArtistPostRequest, Artist>();
            CreateMap<ArtistPutRequest, Artist>();

            CreateMap<Artist, ArtistResponse>();
        }
    }
}