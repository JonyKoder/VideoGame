using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Repository;
using VideoGame.DAL;

namespace VideoGame.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private GameContext _gameContext;
        public UnitOfWork(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        private GameRepository gameRepository;
        
        public GameRepository GamesRepository
        {
            get
            {
                if(gameRepository == null)
                {
                    gameRepository = new GameRepository(_gameContext);
                }
                return gameRepository;
            }
        }
        public async Task<bool> Save()
        {
            return await _gameContext.SaveChangesAsync() > 0;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _gameContext.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
                
        }
    }
}
