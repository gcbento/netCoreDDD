﻿using AutoMapper;
using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Models.Request;
using JogosAPI.Application.Models.Response;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;

namespace JogosAPI.Application.Services
{
    public class SaleAppService : BaseAppService<Sale, SaleRequest, SaleResponse, SaleFilter>, ISaleAppService
    {
        public SaleAppService(ISaleRepository repository, 
                              ISaleValidation validation, 
                              IMapper mapper,
                              ILoggerRepository logger) : base(repository, validation, mapper, logger)
        { }
    }
}
