using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Especie
{
    public class EspecieDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertEspecie(Especie especie)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " INSERT INTO ESPECIE (IDESPECIE,NOMEESPECIE) VALUES (@ID,@NOME) ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", especie.IdEspecie);
                    cmd.Parameters.AddWithValue("@NOME", especie.NomeEspecie);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateEspecie(Especie especie)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " UPDATE ESPECIE SET NOMEESPECIE = @NOME WHERE IDESPECIE = @ID ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", especie.IdEspecie);
                    cmd.Parameters.AddWithValue("@NOME", especie.NomeEspecie);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteEspecie(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM ESPECIE WHERE IDESPECIE = @ID";
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

        public static List<Especie> GetEspecies()
        {
            List<Especie> _Especie = new List<Especie>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDESPECIE, NOMEESPECIE FROM ESPECIE ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var especie = new Especie();

                                especie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                especie.NomeEspecie = dr["NOMEESPECIE"].ToString();

                                _Especie.Add(especie);
                            }
                        }
                        return _Especie;
                    }
                }
            }
        }

        public static Especie GetEspecie(int id)
        {
            Especie especie = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDESPECIE, NOMEESPECIE FROM ESPECIE WHERE IDESPECIE = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                especie = new Especie();
                                especie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                especie.NomeEspecie = dr["NOMEESPECIE"].ToString();
                            }
                        }
                        return especie;
                    }
                }
            }
        }
    }
}