using Practica1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.DataAccess
{
    public class MyDataAcces
    {
        private string Conexion = "Data Source=DESKTOP-UR681EI;Initial Catalog=Practica1;Integrated Security=True;";
        public ObservableCollection<Usuario> GetListUsuario()
        {
            using (SqlConnection connection = new SqlConnection(Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT IdUsuario,Nombre,ApellidoPaterno,ApellidoMaterno,Edad FROM Usuario", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ObservableCollection<Usuario> listUsuario = new ObservableCollection<Usuario>();
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = (int)reader["IdUsuario"],
                                Nombre = (string)reader["Nombre"],
                                ApellidoPaterno = (string)reader["ApellidoPaterno"],
                                ApellidoMaterno = (string)reader["ApellidoMaterno"],
                                Edad = (int)reader["Edad"],
                            };
                            listUsuario.Add(usuario);
                        }
                        return listUsuario;
                    }
                }
            }
        }
        
        public bool SaveUsuario(Usuario user)
        {
            bool resultado = false;
            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SpInsUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", user.Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", user.ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", user.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Edad", user.Edad);
                    var responsereader = command.ExecuteReader();
                    while (responsereader.Read())
                    {
                        usuario.IdUsuario = (int)responsereader["IdUsuario"];
                        usuario.Nombre = (string)responsereader["Nombre"];
                        usuario.ApellidoPaterno = (string)responsereader["ApellidoPaterno"];
                        usuario.ApellidoMaterno = (string)responsereader["ApellidoMaterno"];
                        usuario.Edad = (int)responsereader["Edad"];
                    }
                    resultado = !string.IsNullOrEmpty(usuario.Nombre);
                }
            }
            return resultado;
        }

        public bool UpdateUsuario(Usuario user)
        {
            bool resultado = false;
            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SpUpdUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuaro", user.IdUsuario
                        );
                    command.Parameters.AddWithValue("@Nombre", user.Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", user.ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", user.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Edad", user.Edad);
                    var responsereader = command.ExecuteReader();
                    while (responsereader.Read())
                    {
                        usuario.IdUsuario = (int)responsereader["IdUsuario"];
                        usuario.Nombre = (string)responsereader["Nombre"];
                        usuario.ApellidoPaterno = (string)responsereader["ApellidoPaterno"];
                        usuario.ApellidoMaterno = (string)responsereader["ApellidoMaterno"];
                        usuario.Edad = (int)responsereader["Edad"];
                    }
                    resultado = !string.IsNullOrEmpty(usuario.Nombre);
                }
            }
            return resultado;
        }

    }
}
