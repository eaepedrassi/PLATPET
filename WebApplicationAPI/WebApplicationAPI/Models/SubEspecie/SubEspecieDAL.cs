using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.SubEspecie
{
    public class SubEspecieDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertSubEspecie(SubEspecie subespecie)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO SUBESPECIE (IDESPECIE, NOMESUBESPECIE) VALUES (@IDESPECIE, @NOMESUBESPECIE)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDESPECIE", subespecie.IdSubEspecie);
                    cmd.Parameters.AddWithValue("@NOME", subespecie.NomeSubEspecie);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateSubEspecie(SubEspecie subespecie)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE ESPECIE SET IDESPECIE = @ESPECIE, NOMESUBESPECIE = @NOME ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ESPECIE", subespecie.IdEspecie);
                    cmd.Parameters.AddWithValue("@NOME", subespecie.NomeSubEspecie);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteSubEspecie(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM SUBESPECIE WHERE IDSUBESPECIE = @ID";
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

        public static List<SubEspecie> GetSubEspecies()
        {
            List<SubEspecie> _SubEspecie = new List<SubEspecie>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSUBESPECIE, IDESPECIE, NOMESUBESPECIE FROM SUBESPECIE", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var subespecie = new SubEspecie();

                                subespecie.IdSubEspecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                subespecie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                subespecie.NomeSubEspecie = dr["NOMESUBESPECIE"].ToString();

                                _SubEspecie.Add(subespecie);
                            }
                        }
                        return _SubEspecie;
                    }
                }
            }
        }

        public static SubEspecie GetSubEspecie(int id)
        {
            SubEspecie subespecie = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSUBESPECIE, IDESPECIE, NOMESUBESPECIE FROM SUBESPECIE WHERE IDSUBESPECIE = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                subespecie = new SubEspecie();
                                subespecie.IdSubEspecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                subespecie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                subespecie.NomeSubEspecie = dr["NOME"].ToString();
                            }
                        }
                        return subespecie;
                    }
                }
            }
        }

        public static List<SubEspecie> GetSubEspecieEspecies(int id)
        {
            List<SubEspecie> _SubEspecie = new List<SubEspecie>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSUBESPECIE, IDESPECIE, NOMESUBESPECIE FROM SUBESPECIE WHERE IDESPECIES = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var subespecie = new SubEspecie();

                                subespecie.IdSubEspecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                subespecie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                subespecie.NomeSubEspecie = dr["NOMESUBESPECIE"].ToString();

                                _SubEspecie.Add(subespecie);
                            }
                        }
                        return _SubEspecie;
                    }
                }
            }

        }
    }
}