using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JogosAPI.Application.Models.Request
{
    public class PurchaseRequest : BaseRequest
    {
        [Required(ErrorMessage = "PurchaseDate é obrigatório")]
        public DateTime? PurchaseDate { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal? Value { get; set; }

        [Required(ErrorMessage = "GameId é obrigatório")]
        public int? GameId { get; set; }
    }
}
