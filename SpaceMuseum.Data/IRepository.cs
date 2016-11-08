using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Data
{
    public interface IRepository<T> where T: class
    {
        T Get();
        bool Save(T entity);
        bool Delete(T entity);
        IQueryable<T> Query();
    }
}
