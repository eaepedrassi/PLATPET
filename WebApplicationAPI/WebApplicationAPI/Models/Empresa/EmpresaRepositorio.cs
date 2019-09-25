using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.Empresa
{
    public class EmpresaRepositorio : IRepositorio<Empresa>
    {

        public void Delete(Empresa item)
        {
            EmpresaDAL.DeleteEmpresa(item.IdEmpresa);
        }

        public IEnumerable<Empresa> GetAll()
        {
            return EmpresaDAL.GetEmpresas();
        }

        public Empresa GetById(int id)
        {
            return EmpresaDAL.GetEmpresa(id);
        }

        public void Insert(Empresa item)
        {
            EmpresaDAL.InsertEmpresa(item);
        }

        public void Update(Empresa item)
        {
            EmpresaDAL.UpdateEmpresa(item);
        }

    }
}