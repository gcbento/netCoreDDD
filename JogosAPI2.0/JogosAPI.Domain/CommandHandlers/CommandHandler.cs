using FluentValidation.Results;
using JogosAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.CommandHandlers
{
    public static class CommandHandler
    {
        public static string[] NotifyValidationErrors(IList<ValidationFailure> errors)
        {
            List<string> messageErrors = null;
            if (errors != null && errors.Count > 0)
            {
                messageErrors = new List<string>();
                foreach (var error in errors)
                {
                    messageErrors.Add(error.ErrorMessage);
                }

                return messageErrors.ToArray();
            }

            return null;
        }
    }
}
