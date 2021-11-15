using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Token
    {
        public int Id { get; set; }

        public string TokenName { get; set; }

        public DateTime CreationTime { get; set; }

        public string Role { get; set; }

        public int UserId { get; set; }

        public UserAntigo UserToken { get; set; }
    }
}
