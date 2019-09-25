using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.CadUsuario
{
    public class CadUsuarioDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
        }

        public static int InsertCadUsuario(CadUsuario cadusuario,int tpuser)
        {
            int reg = 0;

            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " INSERT INTO USUARIO (USERUSUARIO,PASSUSUARIO,TIPOUSUARIO,STATUSUSUARIO) VALUES (@USER,@PASS,@TIPO,@STATUS) ";
                if (tpuser == 2)
                {
                    sql += " INSERT INTO PESSOA (IDUSUARIO,CPFPESSOA,TELPESSOA,EMAILPESSOA,ENDPESSOA,NOMEPESSOA,SOBRENOMEPESSOA)	VALUES	(SCOPE_IDENTITY() ,@CGC,@TEL,@EMAIL,@END,@NOME,@SNOME) ";
                }
                else
                {
                    sql += " INSERT INTO EMPRESA	(IDUSUARIO,CNPJEMPRESA,TELEMPRESA,ENDEMPRESA,EMAILEMPRESA,NFANTASIAEMPRESA,RAZAOEMPRESA) VALUES (SCOPE_IDENTITY() ,@CGC,@TEL,@EMAIL,@END,@NOME,@SNOME) ";
                }
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@USER", cadusuario.UserUsuario);
                    cmd.Parameters.AddWithValue("@PASS", cadusuario.PassUsuario);
                    cmd.Parameters.AddWithValue("@TIPO", cadusuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@STATUS", cadusuario.StatusUsuario);
                    cmd.Parameters.AddWithValue("@CGC", cadusuario.CGCEP);
                    cmd.Parameters.AddWithValue("@NOME", cadusuario.NomeEP);
                    cmd.Parameters.AddWithValue("@SNOME", cadusuario.SnomeEP);
                    cmd.Parameters.AddWithValue("@EMAIL", cadusuario.EmailEP);
                    cmd.Parameters.AddWithValue("@TEL", cadusuario.TelEP);
                    cmd.Parameters.AddWithValue("@END", cadusuario.EndEP);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateCadUsuario(CadUsuario cadusuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE PESSOA SET IDUSUARIO = @IDUSUARIO,  CPFPESSOA = @CPFPESSOA, NOMEPESSOA = @NOMEPESSOA, SOBRENOMEPESSOA = @SOBRENOMEPESSOA, EMAILPESSOA = @EMAILPESSOA, TELPESSOA = @TELPESSOA, ENDPESSOA = @ENDPESSOA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PASS", cadusuario.PassUsuario);
                    cmd.Parameters.AddWithValue("@STATUS", cadusuario.StatusUsuario);
                    cmd.Parameters.AddWithValue("@CGC", cadusuario.CGCEP);
                    cmd.Parameters.AddWithValue("@NOME", cadusuario.NomeEP);
                    cmd.Parameters.AddWithValue("@SNOME", cadusuario.SnomeEP);
                    cmd.Parameters.AddWithValue("@EMAIL", cadusuario.EmailEP);
                    cmd.Parameters.AddWithValue("@TEL", cadusuario.TelEP);
                    cmd.Parameters.AddWithValue("@END", cadusuario.EndEP);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        /*
        public static int DeleteCadUsuario(int id)
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
        */
        public static List<CadUsuario> GetCadUsuarios()
        {
            List<CadUsuario> _CadUsuario = new List<CadUsuario>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO,USUARIO.USERUSUARIO,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA+' '+PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'admin' END AS NOMEUSUARIO,USUARIO.PASSUSUARIO,USUARIO.TIPOUSUARIO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAILUSUARIO, STATUSUSUARIO FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cadusuario = new CadUsuario();

                                cadusuario.IdUsuario = Convert.ToInt32(dr["USUARIO.IDUSUARIO"]);
                                cadusuario.UserUsuario = dr["USUARIO.USERUSUARIO"].ToString();
                                cadusuario.PassUsuario = dr["USUARIO.PASSUSUARIO"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["USUARIO.TIPOUSUARIO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUSUSUARIO"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["EMAILPESSOA"].ToString();
                                cadusuario.NomeEP = dr["NOMEUSUARIO"].ToString();
                                cadusuario.SnomeEP = dr["SNOMEUSUARIO"].ToString();
                                cadusuario.EmailEP = dr["EMAILUSUARIO"].ToString();
                                cadusuario.TelEP = dr["ENDUSUARIO"].ToString();
                                cadusuario.EndEP = dr["TELUSUARIO"].ToString();

                                _CadUsuario.Add(cadusuario);
                            }
                        }
                        return _CadUsuario;
                    }
                }
            }
        }

        public static CadUsuario GetCadUsuario(int id)
        {
            CadUsuario cadusuario = null;
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
                                cadusuario = new CadUsuario();
                                cadusuario.IdUsuario = Convert.ToInt32(dr["USUARIO.IDUSUARIO"]);
                                cadusuario.UserUsuario = dr["USUARIO.USERUSUARIO"].ToString();
                                cadusuario.PassUsuario = dr["USUARIO.PASSUSUARIO"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["USUARIO.TIPOUSUARIO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUSUSUARIO"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["EMAILPESSOA"].ToString();
                                cadusuario.NomeEP = dr["NOMEUSUARIO"].ToString();
                                cadusuario.SnomeEP = dr["SNOMEUSUARIO"].ToString();
                                cadusuario.EmailEP = dr["EMAILUSUARIO"].ToString();
                                cadusuario.TelEP = dr["ENDUSUARIO"].ToString();
                                cadusuario.EndEP = dr["TELUSUARIO"].ToString();
                            }
                        }
                        return cadusuario;
                    }
                }
            }
        }
    }
}