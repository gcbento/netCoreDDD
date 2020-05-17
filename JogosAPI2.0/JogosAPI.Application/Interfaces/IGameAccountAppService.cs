using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Filters;

namespace JogosAPI.Application.Interfaces
{
    public interface IGameAccountAppService
    {
        ResponseModel<bool?> DeleteByKey(GameAccountRequest request);
    }
}
