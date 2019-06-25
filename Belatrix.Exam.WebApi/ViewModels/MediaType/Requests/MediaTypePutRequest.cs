using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.Exam.WebApi.ViewModels.MediaType.Requests
{
    public class MediaTypePutRequest
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
    }
}
