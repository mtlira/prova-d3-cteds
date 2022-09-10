using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prova.Models;
using System.Data.SqlClient;

namespace prova.Repositories
{
    internal class UserRepository
    {
        private readonly string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_20; User id=usuario_20; pwd=5174811114;";
        public User GetUser(string email)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * from usuario WHERE email = @Email";


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        user = new()
                        {
                            Id = rdr["id"].ToString(),
                            Nome = rdr["nome"].ToString(),
                            Email = rdr["email"].ToString(),
                            Senha = rdr["senha"].ToString()
                        };

                    }
                }
            }

            return user;
        }
    }
    
}
