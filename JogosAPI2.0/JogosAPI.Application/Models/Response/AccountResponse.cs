using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Models.Response
{
    public class AccountResponse : BaseResponse
    {
        public AccountResponse()
        {
            Games = new List<GameResponse>();
        }

        public string Email { get; set; }
        public string PassWord { get; set; }
        public string OnlineId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeactivationDate { get; set; }
        public List<GameResponse> Games { get; set; }
    }
}
