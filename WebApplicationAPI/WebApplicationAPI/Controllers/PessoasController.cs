using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationAPI.Models.Pessoa;

namespace WebApplicationAPI.Controllers
{
    public class PessoasController : ApiController
    {
        // GET: Usuarios
        private readonly PessoaRepositorio _pessoasRepositorio;

        public PessoasController()
        {
            _pessoasRepositorio = new PessoaRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Pessoa> List()
        {
            return _pessoasRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Pessoa GetPessoa(int id)
        {
            var Pessoa = _pessoasRepositorio.GetById(id);


            return Pessoa;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Pessoa pessoa)
        {
            _pessoasRepositorio.Insert(pessoa);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Pessoa pessoa)
        {
            _pessoasRepositorio.Update(pessoa);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Pessoa p = new Pessoa();
            p.IdPessoa = id;
            _pessoasRepositorio.Delete(p);
        }

    }

}