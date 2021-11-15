using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Data
{
    public class FindIdByName
    {
        public List<int> returnId(List<Game> jogos)
        {
            List<int> ids = new List<int>();
            foreach (Game game in jogos)
                ids.Add(game.Id);
            return ids;
        }
    }
}
