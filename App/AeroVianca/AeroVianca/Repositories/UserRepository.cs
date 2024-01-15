using System.Net;
using System.Data;
using System.Data.SqlClient;
using AeroVianca.Model;
using System.Reflection.PortableExecutable;
using AeroVianca.Interfaces;

namespace AeroVianca.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public string Add(UserModel userModel)
        {
            try
            {
                string queryString = $"insert into [User] " +
                                     $"values (NEWID(), '{userModel.Username}', '{userModel.Password}', '{userModel.Name}', '{userModel.Email}')";

                using var connection = GetConnection();
                using var command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = queryString;

                var execute = command.ExecuteNonQuery();
                return string.Empty;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                return $"ERROR: Fallo la creacion del Usuario: {userModel.Name} \nviolacion de llave primaria en Usuario: {userModel.Username} \no correo: {userModel.Email} ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AuthenticateUser(NetworkCredential credential)
        {
            try
            {
                if (GetByUsername(credential.UserName) == null) return $"el usuario ingresado: {credential.UserName} no existe";
                string queryString = $"select * from [User] where username = '{credential.UserName}' and [password] = '{credential.Password}'";
                return ExecuteQueryUser(queryString) != null ? string.Empty : "* Usuario ó contraseña incorrecto ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UserModel? GetByUsername(string username)
        {
            try
            {
                string queryString = $"select * from [User] where username = '{username}' ";
                return ExecuteQueryUser(queryString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private UserModel? ExecuteQueryUser(string pQueryString)
        {
            try
            {
                using var connection = GetConnection();
                using var command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = pQueryString;

                using var reader = command.ExecuteReader();
                UserModel? user = null;
                if (reader.Read())
                {
                    user = new UserModel()
                    {
                        Id = reader[0]?.ToString() ?? string.Empty,
                        Username = reader[1]?.ToString() ?? string.Empty,
                        Password = string.Empty,
                        Name = reader[3]?.ToString() ?? string.Empty,
                        Email = reader[4]?.ToString() ?? string.Empty,
                    };
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
