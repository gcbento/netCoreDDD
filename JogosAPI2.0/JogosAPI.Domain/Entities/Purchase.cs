using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Purchase : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public decimal Value { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
