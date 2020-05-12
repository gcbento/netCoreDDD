using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public decimal Value { get; set; }

        public DateTime SaleDate { get; set; }

        public DateTime StartDatePeriod { get; set; }

        public DateTime EndDatePeriod { get; set; }

        public Game Game { get; set; }
    }
}
