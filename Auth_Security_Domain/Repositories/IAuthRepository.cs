using Auth_Security_Domain.Commands;
using Auth_Security_Domain.Entities;
using Auth_Security_Domain.Queries;

namespace Auth_Security_Domain.Repositories
{
    public interface IAuthRepository
    {
        public void Handle(EnregistrementCommand cmd);
        public Utilisateur Handle(ConnexionQuery query);
    }
}
