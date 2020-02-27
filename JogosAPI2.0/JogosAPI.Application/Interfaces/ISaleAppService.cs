using JogosAPI.Application.Models;
using JogosAPI.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Interfaces
{
    public interface ISaleAppService : IBaseAppService<SaleModel, SaleFilter>
    {
    }
}
