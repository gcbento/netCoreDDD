using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class WishGame : BaseEntity
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
