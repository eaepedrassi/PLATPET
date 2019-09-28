using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.SubEspecie
{
    public class SubEspecieRepositorio : IRepositorio<SubEspecie>
    {

        public void Delete(SubEspecie item)
        {
            SubEspecieDAL.DeleteSubEspecie(item.IdSubEspecie);
        }

        public IEnumerable<SubEspecie> GetAll()
        {
            return SubEspecieDAL.GetSubEspecies();
        }

        public SubEspecie GetById(int id)
        {
            return SubEspecieDAL.GetSubEspecie(id);
        }

        public void Insert(SubEspecie item)
        {
            SubEspecieDAL.InsertSubEspecie(item);
        }

        public void Update(SubEspecie item)
        {
            SubEspecieDAL.UpdateSubEspecie(item);
        }
        public IEnumerable<SubEspecie> GetByIdEspecies(int id)
        {
            return SubEspecieDAL.GetSubEspecieEspecies(id);
        }

    }
}