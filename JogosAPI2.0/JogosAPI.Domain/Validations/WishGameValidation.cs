using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Validations
{
    public class WishGameValidation : BaseValidation<WishGame, WishGameFilter, IWishGameRepository>, IWishGameValidation
    {
        public WishGameValidation(IWishGameRepository repository) : base(repository)
        {

        }
    }
}
