using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Filters
{
    public class GameAccountFilter : BaseFilter
    {
        public int GameId { get; set; }
        public int AccountId { get; set; }
    }
}
