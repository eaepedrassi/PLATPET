using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationAPI.Models.Especie;

namespace WebApplicationAPI.Controllers
{
    public class EspeciesController : ApiController
    {
        // GET: Usuarios
        private readonly EspecieRepositorio _especiesRepositorio;

        public EspeciesController()
        {
            _especiesRepositorio = new EspecieRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Especie> List()
        {
            return _especiesRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Especie GetEspecie(int id)
        {
            var Especie = _especiesRepositorio.GetById(id);


            return Especie;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Especie especie)
        {
            _especiesRepositorio.Insert(especie);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Especie especie)
        {
            _especiesRepositorio.Update(especie);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Especie e = new Especie();
            e.IdEspecie = id;
            _especiesRepositorio.Delete(e);
        }

    }

}