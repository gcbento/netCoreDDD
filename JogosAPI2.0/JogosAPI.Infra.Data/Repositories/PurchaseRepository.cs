using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;

namespace JogosAPI.Infra.Data.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase, PurchaseFilter>, IPurchaseRepository
    {
        public PurchaseRepository(JogosAPIContext context) : base(context)
        { }
    }
}
