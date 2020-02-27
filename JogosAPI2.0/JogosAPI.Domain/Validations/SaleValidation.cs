using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Validations.Interfaces;

namespace JogosAPI.Domain.Validations
{
    public class SaleValidation : BaseValidation<Sale, SaleFilter>, ISaleValidation
    {
        public SaleValidation(ISaleRepository repository ) : base(repository)
        {

        }
    }
}
