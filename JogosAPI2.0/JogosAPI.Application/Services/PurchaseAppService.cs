using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.CommandHandlers;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Queries;
using JogosAPI.Domain.Util;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosAPI.Application.Services
{
    public class PurchaseAppService: BaseAppService<Purchase, PurchaseRequest, PurchaseResponse, PurchaseFilter>, IPurchaseAppService
    {
        public PurchaseAppService(IPurchaseRepository repository, 
                                  IPurchaseValidation validation, 
                                  IMapper mapper, 
                                  ILoggerRepository logger) : base(repository, validation, mapper, logger)
        { }
    }
}
