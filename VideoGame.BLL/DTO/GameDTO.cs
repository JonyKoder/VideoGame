using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.DAL.Model;

namespace VideoGame.BLL.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string Studio { get; set; }
        public bool Validate()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Studio != null) return true;
            return false;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
