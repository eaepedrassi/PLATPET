using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models.CadUsuario
{
    public class CadUsuarioRepositorio
    {
        /*
        public void Delete(CadUsuario item)
        {
            CadUsuarioDAL.DeleteCadUsuario(item.IdPessoa);
        }
        */
        public IEnumerable<CadUsuario> GetAll()
        {
            return CadUsuarioDAL.GetCadUsuarios();
        }

        public CadUsuario GetById(int id)
        {
            return CadUsuarioDAL.GetCadUsuario(id);
        }

        public void Insert(CadUsuario item,int tpuser)
        {
            CadUsuarioDAL.InsertCadUsuario(item,tpuser);
        }

        public void Update(CadUsuario item,int tpuser)
        {
            CadUsuarioDAL.UpdateCadUsuario(item,tpuser);
        }

    }
}