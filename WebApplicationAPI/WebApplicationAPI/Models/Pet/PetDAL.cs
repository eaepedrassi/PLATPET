using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Pet
{
    public class PetDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["CONEXAOPLATPET"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPet(Pet pet)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO PET (IDPET, IDPESSOA, IDSUBESPECIE, RGPET, OBSPET, NOMEPET) VALUES (@IDPET, @IDPESSOA, @IDSUBE, @RGPET, @OBS, @NOME)";
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
                string sql = "UPDATE PET SET IDPESSOA = @PESSOA, IDSUBESPECIE = @SUBE, RGPET = @RGPET, OBSPET = @OBS, NOMEPET = @NOME ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PESSOA", pet.IdPessoa);
                    cmd.Parameters.AddWithValue("@SUBE", pet.IdSubespecie);
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
                string sql = "DELETE FROM PET WHERE IDPET = @ID";
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

        public static List<Pet> GetPets()
        {
            List<Pet> _Pet = new List<Pet>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPET, IDPESSOA, IDSUBESPECIE, RGPET, OBSPET, NOMEPET FROM PET", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pet = new Pet();

                                pet.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOMEPET"].ToString();
                                pet.ObsPet = dr["OBSPET"].ToString();

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
                using (SqlCommand cmd = new SqlCommand("SELECT IDPET, IDPESSOA, IDSUBESPECIE, RGPET, OBSPET, NOMEPET FROM PET WHERE IDPET = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                pet = new Pet();
                                pet.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOMEPET"].ToString();
                                pet.ObsPet = dr["OBSPET"].ToString();
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
                using (SqlCommand cmd = new SqlCommand("SELECT IDPET, IDPESSOA, IDESPECIE, IDSUBESPECIE, RGPET, OBSPET, NOMEPET FROM PET WHERE IDPESSOA = @ID", con))
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
                                pet.IdSubespecie = Convert.ToInt32(dr["IDSUBESPECIE"]);
                                pet.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pet.RGPet = dr["RGPET"].ToString();
                                pet.NomePet = dr["NOMEPET"].ToString();
                                pet.ObsPet = dr["OBSPET"].ToString();

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