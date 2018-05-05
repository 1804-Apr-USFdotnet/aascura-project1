using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public interface IRepository<T> where T : IEntity
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
