using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationAPI.Models.Empresa;

namespace WebApplicationAPI.Controllers
{
    public class EmpresasController : ApiController
    {
        // GET: Usuarios
        private readonly EmpresaRepositorio _empresasRepositorio;

        public EmpresasController()
        {
            _empresasRepositorio = new EmpresaRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Empresa> List()
        {
            return _empresasRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Empresa GetEmpresa(int id)
        {
            var Empresa = _empresasRepositorio.GetById(id);


            return Empresa;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Empresa empresa)
        {
            _empresasRepositorio.Insert(empresa);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Empresa empresa)
        {
            _empresasRepositorio.Update(empresa);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Empresa e = new Empresa();
            e.IdEmpresa = id;
            _empresasRepositorio.Delete(e);
        }

    }

}