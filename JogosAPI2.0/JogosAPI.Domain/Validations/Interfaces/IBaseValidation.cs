using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Validations.Interfaces
{
    public interface IBaseValidation<T> : IValidator<T>
    {
    }
}
