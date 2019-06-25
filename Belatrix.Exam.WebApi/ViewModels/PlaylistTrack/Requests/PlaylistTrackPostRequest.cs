using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.PlaylistTrack.Requests
{
    public class PlaylistTrackPostRequest
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
    }
}
