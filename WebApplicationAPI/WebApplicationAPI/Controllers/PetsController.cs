using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationAPI.Models.Pet;

namespace WebApplicationAPI.Controllers
{
    public class PetsController : ApiController
    {
        // GET: Usuarios
        private readonly PetRepositorio _petsRepositorio;

        public PetsController()
        {
            _petsRepositorio = new PetRepositorio();
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Pet> List()
        {
            return _petsRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Pet GetPet(int id)
        {
            var Pet = _petsRepositorio.GetById(id);


            return Pet;
        }

        // POST: api/Clientes   
        [HttpPost()]
        public void Post([FromBody]Pet pet)
        {
            _petsRepositorio.Insert(pet);
        }

        // PUT: api/Clientes/5
        [HttpPut()]
        public void Put([FromBody]Pet pet)
        {
            _petsRepositorio.Update(pet);
        }

        // DELETE: api/Clientes/5
        [HttpDelete()]
        public void Delete(int id)
        {
            Pet p = new Pet();
            p.IdPet = id;
            _petsRepositorio.Delete(p);
        }

    }

}