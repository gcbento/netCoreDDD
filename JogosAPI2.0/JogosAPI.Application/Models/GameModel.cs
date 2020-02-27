using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Models
{
    public class GameModel : BaseModel
    {
        public string Name { get; set; }

        public bool Completed { get; set; }
    }
}
