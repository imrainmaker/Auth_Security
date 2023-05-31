
namespace Auth_Security_Domain.Entities
{
    public class Utilisateur
    {
        public Utilisateur(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }

        public Utilisateur(int id, string nom, string prenom, string email)
        : this(nom, prenom, email, null)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string? Passwd { get; set; }
    }
}
