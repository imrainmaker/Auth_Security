using Auth_Security_Domain.Commands;
using Auth_Security_Domain.Entities;
using Auth_Security_Domain.Queries;
using Auth_Security_Domain.Repositories;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Auth_Security_Domain.Services
{
    public class AuthService : IAuthRepository
    {

        private readonly IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Handle(EnregistrementCommand command)
        {
            using (SqlConnection c = new SqlConnection(_dbConnection.ConnectionString))
            {

                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "dbo.NewUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "@nom", command.Nom },
                        { "@prenom", command.Prenom },
                        { "@mail", command.Email },
                        { "@passwd", command.Passwd },

                    };

                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    c.Open();

                    cmd.ExecuteNonQuery();

                    c.Close();

                };
            }
        }

        public Utilisateur? Handle(ConnexionQuery query)
        {
            using (SqlConnection c = new SqlConnection(_dbConnection.ConnectionString))
            {

                using (SqlCommand cmd = c.CreateCommand())
                {
                    Utilisateur utilisateur = null;
                    cmd.CommandText = "dbo.Connexion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "@mail", query.Email },
                        { "@passwd", query.Passwd },

                    };

                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    c.Open();
                    

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string email = (string)reader["mail"];
                            string nom = (string)reader["nom"];
                            string prenom = (string)reader["prenom"];

                            utilisateur = new Utilisateur(id, email, nom, prenom);
                        }
                    }

                    c.Close();

                    return utilisateur is not null ? utilisateur : null;
                };
            }
        }
    }
}
