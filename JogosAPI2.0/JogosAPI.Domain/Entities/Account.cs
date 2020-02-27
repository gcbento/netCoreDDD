using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string OnlineId { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeactivationDate { get; set; }

        [NotMapped]
        public int GameId { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
