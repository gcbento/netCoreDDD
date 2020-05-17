using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JogosAPI.Application.Models.Request
{
    public class SaleRequest : BaseRequest
    {
        [Required (ErrorMessage = "Valor é obrigatório")]
        public decimal? Value { get; set; }

        [Required (ErrorMessage = "SaleDate é obrigatório")]
        public DateTime? SaleDate { get; set; }

        [Required (ErrorMessage = "StartDatePeriod é obrigatório")]
        public DateTime? StartDatePeriod { get; set; }

        [Required(ErrorMessage = "EndDatePeriod é obrigatório")]
        public DateTime? EndDatePeriod { get; set; }

        [Required(ErrorMessage = "GameId é obrigatório")]
        public int? GameId { get; set; }
    }
}
