using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Repository;

namespace VideoGame.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        GameRepository GamesRepository { get; }

        
        Task<bool> Save();

    }
}
