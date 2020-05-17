using System.Collections.Generic;

namespace JogosAPI.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public bool Completed { get; set; }

        public List<GameAccount> Accounts { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
