using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
                string sql = "INSERT INTO EMPRESA (IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA) VALUES (@IDUSUARIO, @CNPJEMPRESA, @NFANTASIAEMPRESA, @RAZAOEMPRESA, @EMAILEMPRESA, @TELEMPRESA, @ENDEMPRESA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDESPECIE", especie.IdEspecie);
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
                string sql = "UPDATE EMPRESA SET IDUSUARIO = @IDUSUARIO, CNPJEMPRESA = @CNPJEMPRESA, NFANTASIAEMPRESA = @NFANTASIAEMPRESA, RAZAOEMPRESA = @RAZAOEMPRESA, EMAILEMPRESA = @EMAILEMPRESA, TELEMPRESA = @TELEMPRESA, ENDEMPRESA = @ENDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
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
                string sql = "DELETE FROM EMPRESA WHERE IDEMPRESA = @IDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDESPECIE", id);

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
                using (SqlCommand cmd = new SqlCommand("SELECT IDEMPRESA, IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA FROM EMPRESA", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var especie = new Especie();

                                especie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                especie.NomeEspecie = dr["NOME"].ToString();

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
                using (SqlCommand cmd = new SqlCommand("SELECT IDEMPRESA, IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA FROM USUARIO WHERE IDEMPRESA = @IDEMPRESA", con))
                {
                    cmd.Parameters.AddWithValue("@IDESPECIE", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                especie = new Especie();
                                especie.IdEspecie = Convert.ToInt32(dr["IDESPECIE"]);
                                especie.NomeEspecie = dr["NOME"].ToString();
                            }
                        }
                        return especie;
                    }
                }
            }
        }
    }
}