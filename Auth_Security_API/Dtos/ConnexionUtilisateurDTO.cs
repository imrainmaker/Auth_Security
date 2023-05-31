using System.ComponentModel.DataAnnotations;

namespace Auth_Security_API.Dtos
{
    public class ConnexionUtilisateurDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Passwd { get; set; }

    }
}
