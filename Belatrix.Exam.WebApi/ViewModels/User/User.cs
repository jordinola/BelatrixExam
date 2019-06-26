using System.ComponentModel.DataAnnotations;

namespace Belatrix.Exam.WebApi.ViewModels.User
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
