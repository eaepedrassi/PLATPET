using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Pessoa
{
    public class PessoaRepositorio
    {

        public void Delete(Pessoa item)
        {
            PessoaDAL.DeletePessoa(item.IdPessoa);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return PessoaDAL.GetPessoas();
        }

        public Pessoa GetById(int id)
        {
            return PessoaDAL.GetPessoa(id);
        }

        public void Insert(Pessoa item)
        {
            PessoaDAL.InsertPessoa(item);
        }

        public void Update(Pessoa item)
        {
            PessoaDAL.UpdatePessoa(item);
        }

    }
}