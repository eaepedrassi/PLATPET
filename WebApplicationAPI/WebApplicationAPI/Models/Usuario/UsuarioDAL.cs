using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public class UsuarioDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertUsuario(Usuario usuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO USUARIO (USERUSUARIO, PASSUSUARIO, TIPOUSUARIO, STATUSUSUARIO) VALUES (@USERUSUARIO, @PASSUSUARIO, @TIPOUSUARIO, @STATUSUSUARIO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@USERUSUARIO", usuario.UserUsuario);
                    cmd.Parameters.AddWithValue("@PASSUSUARIO", usuario.PassUsuario);
                    cmd.Parameters.AddWithValue("@TIPOUSUARIO", usuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@STATUSUSUARIO", usuario.StatusUsuario);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateUsuario(Usuario usuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE USUARIO SET USERUSUARIO = @USERUSUARIO, PASSUSUARIO = @PASSUSUARIO, TIPOUSUARIO = @TIPOUSUARIO, STATUSUSUARIO = @STATUSUSUARIO  WHERE IDUSUARIO = @ID ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@USERUSUARIO", usuario.UserUsuario);
                    cmd.Parameters.AddWithValue("@PASSUSUARIO", usuario.PassUsuario);
                    cmd.Parameters.AddWithValue("@TIPOUSUARIO", usuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@STATUSUSUARIO", usuario.UserUsuario);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteUsuario(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM USUARIO WHERE IDUSUARIO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> _Usuarios = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSUARIO, USERUSUARIO, PASSUSUARIO, TIPOUSUARIO, STATUSUSUARIO FROM USUARIO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();

                                usuario.IdUsuario       = Convert.ToInt32(dr["IDUSUARIO"]);
                                usuario.UserUsuario     = dr["USERUSUARIO"].ToString();
                                usuario.PassUsuario     = dr["PASSUSUARIO"].ToString();
                                usuario.TipoUsuario     = Convert.ToInt32(dr["TIPOUSUARIO"]);
                                usuario.StatusUsuario   = Convert.ToInt32(dr["STATUSUSUARIO"]);

                                _Usuarios.Add(usuario);
                            }
                        }
                        return _Usuarios;
                    }
                }
            }
        }

        public static Usuario GetUsuario(int id)
        {
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSUARIO, USERUSUARIO, PASSUSUARIO, TIPOUSUARIO, STATUSUSUARIO FROM USUARIO WHERE IDUSUARIO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                usuario = new Usuario();
                                usuario.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                usuario.UserUsuario = dr["USERUSUARIO"].ToString();
                                usuario.PassUsuario = dr["PASSUSUARIO"].ToString();
                                usuario.TipoUsuario = Convert.ToInt32(dr["TIPOUSUARIO"]);
                                usuario.StatusUsuario = Convert.ToInt32(dr["STATUSUSUARIO"]);
                            }
                        }
                        return usuario;
                    }
                }
            }
        }
    }
}