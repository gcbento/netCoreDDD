using System.Collections.Generic;

namespace JogosAPI.Application.Models.Response
{
    public class GameResponse : BaseResponse
    {
        public GameResponse()
        {
            Accounts = new List<AccountResponse>();
        }

        public string Name { get; set; }
        public bool Completed { get; set; }
        public List<AccountResponse> Accounts { get; set; }
    }
}
