using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Model;

namespace VideoGame.DAL.Repository
{
    public class GameRepository : IRepository<Game>
    {
        private readonly GameContext _gameContext;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public GameRepository(GameContext context)
        {
            _gameContext = context;
        }
        public async Task<bool> Create(Game item)
        {
            try
            {
                await _gameContext.AddAsync(item);
                return await _gameContext.SaveChangesAsync() > 0;
            }
            catch(Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        public async Task<bool> CreateOrUpdate(Game item)
        {
            try
            {
                if (item.Id == 0) return await Create(item);
                return await Update(item);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

        }

        public async Task<bool> Delete(int id)    
        {
            try
            {
                var item = await _gameContext.Games.SingleOrDefaultAsync(x => x.Id == id);
                _gameContext.Entry(item).State = EntityState.Detached;
                _gameContext.Remove(item);
                return await _gameContext.SaveChangesAsync() > 0;
            }
            catch(Exception e)
            {
                _logger.Error(e);
                throw;
            }
            
        }

        public async Task<Game> Get(int id)
        {
            return await _gameContext.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            try
            {
                return await _gameContext.Games.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }

        }

        public async Task<bool> Update(Game item)
        {
            try
            {
                _gameContext.Entry(item).State = EntityState.Modified;
                _gameContext.Update(item);
                return await _gameContext.SaveChangesAsync() > 0;
            }
            catch(Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}
