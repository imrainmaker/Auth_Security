
namespace Auth_Security_Domain.Queries
{
    public  class ConnexionQuery
    {
        public ConnexionQuery(string email, string passwd)
        {
            Email = email;
            Passwd = passwd;
        }

        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
