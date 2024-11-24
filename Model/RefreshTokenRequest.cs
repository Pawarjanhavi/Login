using System.ComponentModel.DataAnnotations;

namespace Login.Model
{
    public class RefreshTokenrequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
