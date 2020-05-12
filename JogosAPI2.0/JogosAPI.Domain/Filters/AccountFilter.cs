using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Filters
{
    public class AccountFilter : BaseFilter
    {
        public string Email { get; set; }
        public string OnlineId { get; set; }
        public int GameId { get; set; } 
    }
}
