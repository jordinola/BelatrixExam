using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.Genre.Requests
{
    public class GenrePutRequest
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
