using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id); 
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
        Task<bool> CreateOrUpdate(T item);

    }
}
