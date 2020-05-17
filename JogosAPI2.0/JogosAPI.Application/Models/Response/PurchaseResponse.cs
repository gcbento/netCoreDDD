using JogosAPI.Domain.Entities;
using Microsoft.VisualBasic;
using System;

namespace JogosAPI.Application.Models.Response
{
    public class PurchaseResponse : BaseResponse
    {
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public GameResponse Game { get; set; }
    }
}
