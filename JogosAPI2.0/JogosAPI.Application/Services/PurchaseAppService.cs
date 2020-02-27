using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Services
{
    public class PurchaseAppService: BaseAppService<Purchase, PurchaseModel, PurchaseFilter>, IPurchaseAppService
    {
        public PurchaseAppService(IPurchaseRepository repository, IPurchaseValidation validation, IMapper mapper) : base(repository, validation, mapper)
        {

        }
    }
}
