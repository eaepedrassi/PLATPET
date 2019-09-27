using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Especie
{
    public class EspecieRepositorio : IRepositorio<Especie>
    {

        public void Delete(Especie item)
        {
            EspecieDAL.DeleteEspecie(item.IdEspecie);
        }

        public IEnumerable<Especie> GetAll()
        {
            return EspecieDAL.GetEspecies();
        }

        public Especie GetById(int id)
        {
            return EspecieDAL.GetEspecie(id);
        }

        public void Insert(Especie item)
        {
            EspecieDAL.InsertEspecie(item);
        }

        public void Update(Especie item)
        {
            EspecieDAL.UpdateEspecie(item);
        }

    }
}