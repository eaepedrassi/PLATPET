using System.Collections.Generic;
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
        public CadUsuario GetCadUsuario(int id)
        {
            var CadUsuario = _cadusuariosRepositorio.GetById(id);

            return CadUsuario;
        }

        // POST: api/Clientes   
        [Route("api/CadUsuarios/{tpuser}")]
        [HttpPost()]
        public void Post([FromBody]CadUsuario cadusuario,int tpuser)
        {
            _cadusuariosRepositorio.Insert(cadusuario,tpuser);
        }

        // PUT: api/Clientes/5
        [Route("api/CadUsuarios/{tpuser}")]
        [HttpPut()]
        public void Put([FromBody]CadUsuario cadusuario,int tpuser)
        {
            _cadusuariosRepositorio.Update(cadusuario,tpuser);
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