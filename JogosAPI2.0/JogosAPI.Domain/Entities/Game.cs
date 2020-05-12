using System.Collections.Generic;

namespace JogosAPI.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public bool Completed { get; set; }

        public List<GameAccount> Accounts { get; set; }
    }
}
