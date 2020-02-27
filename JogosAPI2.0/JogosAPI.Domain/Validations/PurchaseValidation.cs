using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class PurchaseValidation : BaseValidation<Purchase, PurchaseFilter>, IPurchaseValidation
    {
        public PurchaseValidation(IPurchaseRepository repository) : base(repository)
        {

        }
    }
}
