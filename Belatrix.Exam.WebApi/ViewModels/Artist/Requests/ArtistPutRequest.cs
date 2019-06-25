using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.Artist.Requests
{
    public class ArtistPutRequest
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}
