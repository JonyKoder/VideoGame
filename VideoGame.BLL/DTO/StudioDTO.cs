using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Model;

namespace VideoGame.BLL.DTO
{
   public class StudioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
        public bool Validate()
        {
            if (!string.IsNullOrWhiteSpace(Name)) return true;
            return false;
        }
    }
}
