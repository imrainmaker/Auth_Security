
namespace Auth_Security_Domain.Commands
{
    public class EnregistrementCommand
    {
        public EnregistrementCommand(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
