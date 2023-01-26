using System.ComponentModel.DataAnnotations;

namespace WebApiKnowlegde.DTO
{
    public class userCredentials
    {
        [Required(ErrorMessage ="The {0} is requerid, please try again")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The {0} is requerid, please try again")]
        public string Password { get; set; }

    }
}
