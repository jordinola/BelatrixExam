using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
