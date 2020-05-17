using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JogosAPI.Application.Models.Request
{
    public class GameRequest : BaseRequest
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Name { get; set; }

        public bool Completed { get; set; }

        public List<GameAccountRequest> Accounts { get; set; }
    }
}
