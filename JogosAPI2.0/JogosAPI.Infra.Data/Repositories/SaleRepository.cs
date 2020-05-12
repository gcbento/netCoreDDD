using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale, SaleFilter, SaleQuery>, ISaleRepository
    {
        public SaleRepository(JogosAPIContext context) : base(context)
        { }
    }
}
