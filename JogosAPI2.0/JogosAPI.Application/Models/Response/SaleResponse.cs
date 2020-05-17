using JogosAPI.Domain.Entities;
using System;

namespace JogosAPI.Application.Models.Response
{
    public class SaleResponse : BaseResponse
    {
        public decimal Value { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime StartDatePeriod { get; set; }
        public DateTime EndDatePeriod { get; set; }
        public GameResponse Game { get; set; }
    }
}
