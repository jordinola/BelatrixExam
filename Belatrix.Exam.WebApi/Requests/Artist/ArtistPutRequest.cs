using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.Requests.Artist
{
    public class ArtistPutRequest
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}
