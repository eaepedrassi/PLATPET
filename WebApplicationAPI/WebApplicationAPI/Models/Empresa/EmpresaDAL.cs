using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Empresa
{
    public class EmpresaDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertEmpresa(Empresa empresa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO EMPRESA (IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA) VALUES (@IDUSUARIO, @CNPJEMPRESA, @NFANTASIAEMPRESA, @RAZAOEMPRESA, @EMAILEMPRESA, @TELEMPRESA, @ENDEMPRESA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", empresa.IdUsuario);
                    cmd.Parameters.AddWithValue("@CNPJEMPRESA", empresa.CNPJEmpresa);
                    cmd.Parameters.AddWithValue("@NFANTASIAEMPRESA", empresa.NFantasiaEmpresa);
                    cmd.Parameters.AddWithValue("@RAZAOEMPRESA", empresa.RazaoEmpresa);
                    cmd.Parameters.AddWithValue("@EMAILEMPRESA", empresa.EmailEmpresa);
                    cmd.Parameters.AddWithValue("@TELEMPRESA", empresa.TelEmpresa);
                    cmd.Parameters.AddWithValue("@ENDEMPRESA", empresa.EndEmpresa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateEmpresa(Empresa empresa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE EMPRESA SET IDUSUARIO = @IDUSUARIO, CNPJEMPRESA = @CNPJEMPRESA, NFANTASIAEMPRESA = @NFANTASIAEMPRESA, RAZAOEMPRESA = @RAZAOEMPRESA, EMAILEMPRESA = @EMAILEMPRESA, TELEMPRESA = @TELEMPRESA, ENDEMPRESA = @ENDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", empresa.IdUsuario);
                    cmd.Parameters.AddWithValue("@CNPJEMPRESA", empresa.CNPJEmpresa);
                    cmd.Parameters.AddWithValue("@NFANTASIAEMPRESA", empresa.NFantasiaEmpresa);
                    cmd.Parameters.AddWithValue("@RAZAOEMPRESA", empresa.RazaoEmpresa);
                    cmd.Parameters.AddWithValue("@EMAILEMPRESA", empresa.EmailEmpresa);
                    cmd.Parameters.AddWithValue("@TELEMPRESA", empresa.TelEmpresa);
                    cmd.Parameters.AddWithValue("@ENDEMPRESA", empresa.EndEmpresa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteEmpresa(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM EMPRESA WHERE IDEMPRESA = @IDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDEMPRESA", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Empresa> GetEmpresas()
        {
            List<Empresa> _Empresas = new List<Empresa>();

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
                                var empresa = new Empresa();

                                empresa.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                empresa.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                empresa.CNPJEmpresa = dr["CNPJEMPRESA"].ToString();
                                empresa.NFantasiaEmpresa = dr["NFANTASIAEMPRESA"].ToString();
                                empresa.RazaoEmpresa = dr["RAZAOEMPRESA"].ToString();
                                empresa.EmailEmpresa = dr["EMAILEMPRESA"].ToString();
                                empresa.TelEmpresa = dr["TELEMPRESA"].ToString();
                                empresa.EndEmpresa = dr["ENDEMPRESA"].ToString();


                                _Empresas.Add(empresa);
                            }
                        }
                        return _Empresas;
                    }
                }
            }
        }

        public static Empresa GetEmpresa(int id)
        {
            Empresa empresa = null;
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
                                empresa = new Empresa();
                                empresa.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                empresa.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                empresa.CNPJEmpresa = dr["CNPJEMPRESA"].ToString();
                                empresa.NFantasiaEmpresa = dr["NFANTASIAEMPRESA"].ToString();
                                empresa.RazaoEmpresa = dr["RAZAOEMPRESA"].ToString();
                                empresa.EmailEmpresa = dr["EMAILEMPRESA"].ToString();
                                empresa.TelEmpresa = dr["TELEMPRESA"].ToString();
                                empresa.EndEmpresa = dr["ENDEMPRESA"].ToString();
                            }
                        }
                        return empresa;
                    }
                }
            }
        }
    }
}