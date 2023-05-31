using System.ComponentModel.DataAnnotations;

namespace Auth_Security_API.Dtos
{
    public class AjoutUtilisateurDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Passwd { get; set; }
    }
}
