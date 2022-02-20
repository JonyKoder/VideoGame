using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.BLL.Servises
{
    public interface IDataStore<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Delete(int id);
        Task<bool> CreateOrUpdate(T item);
        void Dispose();
    }
}
