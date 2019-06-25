using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Requests.Album
{
    public class AlbumPostRequest
    {
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
