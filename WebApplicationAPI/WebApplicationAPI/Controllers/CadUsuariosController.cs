using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationAPI.Models.CadUsuario;

namespace WebApplicationAPI.Controllers
{
    public class CadUsuariosController : ApiController
    {
        // GET: Usuarios
        private readonly CadUsuarioRepositorio _cadusuariosRepositorio;

        public CadUsuariosController()
        {
            _cadusuariosRepositorio = new CadUsuarioRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<CadUsuario> List()
        {
            return _cadusuariosRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public CadUsuario GetEmpresa(int id)
        {
            var Empresa = _cadusuariosRepositorio.GetById(id);


            return Empresa;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]CadUsuario cadusuario,int tpuser)
        {
            _cadusuariosRepositorio.Insert(cadusuario,tpuser);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]CadUsuario cadusuario)
        {
            _cadusuariosRepositorio.Update(cadusuario);
        }
        /*
        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Empresa e = new Empresa();
            e.IdEmpresa = id;
            _empresasRepositorio.Delete(e);
        }
        */
    }
}