﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JogosAPI.Application.Models.Request
{
    public class AccountRequest : BaseRequest
    {
        [Required(ErrorMessage ="E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Passaword é obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage ="OnlineId é obrigat´roio")]
        public string OnlineId { get; set; }

        [Required(ErrorMessage ="BirthDate é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="DeacvationDate é obrigatório")]
        public DateTime DeactivationDate { get; set; }

        
        public List<int> GamesId { get; set; }
    }
}
