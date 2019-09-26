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
                    cmd.Parameters.AddWithValue("@ENDE", cadusuario.EndEP);

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
                    cmd.Parameters.AddWithValue("@ENDE", cadusuario.EndEP);

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
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO AS ID,USUARIO.USERUSUARIO AS USR,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'administrador' END AS NOME,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.RAZAOEMPRESA ELSE 'platpet' END AS SNOME,USUARIO.PASSUSUARIO AS PASS,USUARIO.TIPOUSUARIO AS TIPO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAIL, STATUSUSUARIO AS STATUS,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.IDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.IDEMPRESA ELSE 0 END AS IDEP,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.CPFPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.CNPJEMPRESA ELSE '' END AS CGC,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.TELPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.TELEMPRESA ELSE '' END AS TEL,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.ENDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.ENDEMPRESA ELSE '' END AS ENDE FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cadusuario = new CadUsuario();

                                cadusuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                                cadusuario.UserUsuario = dr["USR"].ToString();
                                cadusuario.PassUsuario = dr["PASS"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["TIPO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUS"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["CGC"].ToString();
                                cadusuario.NomeEP = dr["NOME"].ToString();
                                cadusuario.SnomeEP = dr["SNOME"].ToString();
                                cadusuario.EmailEP = dr["EMAIL"].ToString();
                                cadusuario.TelEP = dr["ENDE"].ToString();
                                cadusuario.EndEP = dr["TEL"].ToString();

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
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO AS ID,USUARIO.USERUSUARIO AS USR,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'administrador' END AS NOME,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.RAZAOEMPRESA ELSE 'platpet' END AS SNOME,USUARIO.PASSUSUARIO AS PASS,USUARIO.TIPOUSUARIO AS TIPO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAIL, STATUSUSUARIO AS STATUS,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.IDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.IDEMPRESA ELSE 0 END AS IDEP,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.CPFPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.CNPJEMPRESA ELSE '' END AS CGC,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.TELPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.TELEMPRESA ELSE '' END AS TEL,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.ENDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.ENDEMPRESA ELSE '' END AS ENDE FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO WHERE IDEMPRESA = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cadusuario = new CadUsuario();
                                cadusuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                                cadusuario.UserUsuario = dr["USR"].ToString();
                                cadusuario.PassUsuario = dr["PASS"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["TIPO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUS"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["CGC"].ToString();
                                cadusuario.NomeEP = dr["NOME"].ToString();
                                cadusuario.SnomeEP = dr["SNOME"].ToString();
                                cadusuario.EmailEP = dr["EMAIL"].ToString();
                                cadusuario.TelEP = dr["ENDE"].ToString();
                                cadusuario.EndEP = dr["TEL"].ToString();
                            }
                        }
                        return cadusuario;
                    }
                }
            }
        }
    }
}