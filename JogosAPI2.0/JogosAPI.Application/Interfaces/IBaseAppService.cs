using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Filters;
using System.Collections.Generic;

namespace JogosAPI.Application.Interfaces
{
    public interface IBaseAppService<TRequest, TResponse, TFilter> 
        where TRequest : BaseRequest
        where TResponse: BaseResponse
        where TFilter : BaseFilter
    {
        ResponseModel<bool> Add(TRequest model);

        ResponseModel<bool> Update(TRequest model);

        ResponseModel<bool> Delete(int id);

        ResponseModel<TResponse> GetBy(TFilter id);

        ResponseModel<List<TResponse>> GetAll(TFilter filter);
    }
}
