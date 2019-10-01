using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Pet
{
    public class PetDAL
    {

        protected static string GetStringConexao()
        {
            //return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPet(Pet pet)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO EMPRESA (IDUSUARIO, CNPJEMPRESA, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA) VALUES (@IDUSUARIO, @CNPJEMPRESA, @NFANTASIAEMPRESA, @RAZAOEMPRESA, @EMAILEMPRESA, @TELEMPRESA, @ENDEMPRESA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPET", pet.IdPet);
                    cmd.Parameters.AddWithValue("@IDSUBE", pet.IdSubespecie);
                    cmd.Parameters.AddWithValue("@IDPESSOA", pet.IdPessoa);
                    cmd.Parameters.AddWithValue("@RGPET", pet.RGPet);
                    cmd.Parameters.AddWithValue("@NOME", pet.NomePet);
                    cmd.Parameters.AddWithValue("@OBS", pet.ObsPet);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePet(Pet pet)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE EMPRESA SET IDUSUARIO = @IDUSUARIO, CNPJEMPRESA = @CNPJEMPRESA, NFANTASIAEMPRESA = @NFANTASIAEMPRESA, RAZAOEMPRESA = @RAZAOEMPRESA, EMAILEMPRESA = @EMAILEMPRESA, TELEMPRESA = @TELEMPRESA, ENDEMPRESA = @ENDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDSUBE", pet.IdSubespecie);
                    cmd.Parameters.AddWithValue("@RGPET", pet.RGPet);
                    cmd.Parameters.AddWithValue("@NOME", pet.NomePet);
                    cmd.Parameters.AddWithValue("@OBS", pet.ObsPet);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePet(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM EMPRESA WHERE IDEMPRESA = @IDEMPRESA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPET", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Pet> GetPets()
        {
            List<Pet> _Pet = new List<Pet>();

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
                                var pet = new Pet();

                                pet.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOME"].ToString();
                                pet.ObsPet = dr["OBS"].ToString();

                                _Pet.Add(pet);
                            }
                        }
                        return _Pet;
                    }
                }
            }
        }

        public static Pet GetPet(int id)
        {
            Pet pet = null;
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
                                pet = new Pet();
                                pet.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOME"].ToString();
                                pet.ObsPet = dr["OBS"].ToString();
                            }
                        }
                        return pet;
                    }
                }
            }
        }

        public static List<Pet> GetPetsPessoa(int id)
        {
            List<Pet> _Pet = new List<Pet>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPET, IDSUBESPECIE, A, NFANTASIAEMPRESA, RAZAOEMPRESA, EMAILEMPRESA, TELEMPRESA, ENDEMPRESA FROM EMPRESA WHERE IDPESSOA = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pet = new Pet();

                                pet.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOME"].ToString();
                                pet.ObsPet = dr["OBS"].ToString();

                                _Pet.Add(pet);
                            }
                        }
                        return _Pet;
                    }
                }
            }
        }

    }
}