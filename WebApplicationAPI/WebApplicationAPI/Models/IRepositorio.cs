using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public interface IRepositorio<T>
    {
        void Insert(T item);

        void Update(T item);

        void Delete(T item);

        IEnumerable<T> GetAll();

        T GetById(int id);

    }
}