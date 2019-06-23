using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Models
{
    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
