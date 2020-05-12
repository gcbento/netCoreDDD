using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogosAPI.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string OnlineId { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeactivationDate { get; set; }

        public ICollection<GameAccount> Games { get; set; }
    }
}
