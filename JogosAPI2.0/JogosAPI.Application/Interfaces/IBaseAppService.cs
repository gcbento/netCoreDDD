using JogosAPI.Application.Models;
using JogosAPI.Domain.Filters;
using System.Collections.Generic;

namespace JogosAPI.Application.Interfaces
{
    public interface IBaseAppService<TModel, TFilter> 
        where TModel : BaseModel
        where TFilter : BaseFilter
    {
        ResponseModel<TModel> Add(TModel model);

        ResponseModel<bool> Update(TModel model);

        ResponseModel<bool> Delete(int id);

        ResponseModel<TModel> GetBy(TFilter id);

        ResponseModel<List<TModel>> GetAll(TFilter filter);
    }
}
