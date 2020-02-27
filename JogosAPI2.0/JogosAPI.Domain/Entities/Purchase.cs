using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Purchase : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public decimal Value { get; set; }

        public int GamesId { get; set; }

        public virtual Game Games { get; set; }
    }
}
