﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Models
{
    public class MediaType
    {
        public MediaType()
        {
            Tracks = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
