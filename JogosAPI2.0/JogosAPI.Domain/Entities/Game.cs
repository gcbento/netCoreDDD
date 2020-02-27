using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public bool Completed { get; set; }

        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
