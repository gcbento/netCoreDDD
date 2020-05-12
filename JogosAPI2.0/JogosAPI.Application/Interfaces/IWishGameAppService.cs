using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Filters;

namespace JogosAPI.Application.Interfaces
{
    public interface IWishGameAppService : IBaseAppService<WishGameRequest, WishGameResponse, WishGameFilter>
    {
    }
}
