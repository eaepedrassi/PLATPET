using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Pessoa
{
    public class PessoaDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertPessoa(Pessoa pessoa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO PESSOA (IDUSUARIO, CPFPESSOA, NOMEPESSOA, SOBRENOMEPESSOA, EMAILPESSOA, TELPESSOA, ENDPESSOA) VALUES (@IDUSUARIO, @CPFPESSOA, @NOMEPESSOA, @SOBRENOMEPESSOA, @EMAILPESSOA, @TELPESSOA, @ENDPESSOA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", pessoa.IdUsuario);
                    cmd.Parameters.AddWithValue("@CPFPESSOA", pessoa.CPFPessoa);
                    cmd.Parameters.AddWithValue("@NOMEPESSOA", pessoa.NomePessoa);
                    cmd.Parameters.AddWithValue("@SOBRENOMEPESSOA", pessoa.SobrenomePessoa);
                    cmd.Parameters.AddWithValue("@EMAILPESSOA", pessoa.EmailPessoa);
                    cmd.Parameters.AddWithValue("@TELPESSOA", pessoa.TelPessoa);
                    cmd.Parameters.AddWithValue("@ENDPESSOA", pessoa.EndPessoa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePessoa(Pessoa pessoa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE PESSOA SET IDUSUARIO = @IDUSUARIO,  CPFPESSOA = @CPFPESSOA, NOMEPESSOA = @NOMEPESSOA, SOBRENOMEPESSOA = @SOBRENOMEPESSOA, EMAILPESSOA = @EMAILPESSOA, TELPESSOA = @TELPESSOA, ENDPESSOA = @ENDPESSOA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", pessoa.IdUsuario);
                    cmd.Parameters.AddWithValue("@CPFPESSOA", pessoa.CPFPessoa);
                    cmd.Parameters.AddWithValue("@NOMEPESSOA", pessoa.NomePessoa);
                    cmd.Parameters.AddWithValue("@SOBRENOMEPESSOA", pessoa.SobrenomePessoa);
                    cmd.Parameters.AddWithValue("@EMAILPESSOA", pessoa.EmailPessoa);
                    cmd.Parameters.AddWithValue("@TELPESSOA", pessoa.TelPessoa);
                    cmd.Parameters.AddWithValue("@ENDPESSOA", pessoa.EndPessoa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePessoa(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM PESSOA WHERE IDPESSOA = @IDPESSOA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPESSOA", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Pessoa> GetPessoas()
        {
            List<Pessoa> _Pessoa = new List<Pessoa>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPESSOA, IDUSUARIO, CPFPESSOA, NOMEPESSOA, SOBRENOMEPESSOA, EMAILPESSOA, TELPESSOA, ENDPESSOA FROM PESSOA", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pessoa = new Pessoa();

                                pessoa.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pessoa.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                pessoa.CPFPessoa = dr["CPFPESSOA"].ToString();
                                pessoa.NomePessoa = dr["NOMEPESSOA"].ToString();
                                pessoa.SobrenomePessoa = dr["SOBRENOMEPESSOA"].ToString();
                                pessoa.EmailPessoa = dr["EMAILPESSOA"].ToString();
                                pessoa.TelPessoa = dr["TELPESSOA"].ToString();
                                pessoa.EndPessoa = dr["ENDPESSOA"].ToString();


                                _Pessoa.Add(pessoa);
                            }
                        }
                        return _Pessoa;
                    }
                }
            }
        }

        public static Pessoa GetPessoa(int id)
        {
            Pessoa pessoa = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDEMPRESA, IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA FROM USUARIO WHERE IDEMPRESA = @IDEMPRESA", con))
                {
                    cmd.Parameters.AddWithValue("@IDEMPRESA", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                pessoa = new Pessoa();
                                pessoa.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pessoa.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                pessoa.CPFPessoa = dr["CPFPESSOA"].ToString();
                                pessoa.NomePessoa = dr["NOMEPESSOA"].ToString();
                                pessoa.SobrenomePessoa = dr["SOBRENOMEPESSOA"].ToString();
                                pessoa.EmailPessoa = dr["EMAILPESSOA"].ToString();
                                pessoa.TelPessoa = dr["TELPESSOA"].ToString();
                                pessoa.EndPessoa = dr["ENDPESSOA"].ToString();
                            }
                        }
                        return pessoa;
                    }
                }
            }
        }
    }
}