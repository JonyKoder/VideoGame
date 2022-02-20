using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Model;
using VideoGame.DAL;
using VideoGame.BLL.DTO;
using AutoMapper;

namespace VideoGame.BLL.Servises
{
    public class GameServise : IDataStore<GameDTO>
    {
        IUnitOfWork Database { get; set; }
        public GameServise(IUnitOfWork uow)
        {
            Database = uow;
        }
       
        public async Task<bool> CreateOrUpdate(GameDTO item)
        {
            if (!item.Validate()) throw new ValidationException("Некоторые поля не заполнены, операция отменена", item.ToString());
            var result = false;
            var game = new Game
            {
                Id = item.Id,
                Name = item.Name,
                Studio = item.Studio,
                Genre = item.Genre
            };
            using (Database)
                result = await Database.GamesRepository.CreateOrUpdate(game);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            if (id == 0) throw new ValidationException("В базе данных не существует игры");
            var result = false;
            using (Database)
                result = await Database.GamesRepository.Delete(id);
            return result;
            
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<GameDTO> Get(int id)
        {
            Game game = null;
            using (Database)
                game = await Database.GamesRepository.Get(id);
            if (game is null) throw new ValidationException("Нет такой игры");
            return new GameDTO
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Studio = game.Studio
            };
        }

        public async Task<IEnumerable<GameDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Game>, List<GameDTO>>(await Database.GamesRepository.GetAll());
        }
    }
}
