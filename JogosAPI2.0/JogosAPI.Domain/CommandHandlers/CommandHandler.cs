using FluentValidation.Results;
using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Util;
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
        public static string[] NotifyValidationErrors(string msg)
        {
            List<string> messageErrors = null;
            if (!string.IsNullOrEmpty(msg))
            {
                messageErrors = new List<string>();
                messageErrors.Add(msg);

                return messageErrors.ToArray();
            }

            return null;
        }

        public static void AddLogger(ILoggerRepository logger, string msg, EnunsAPI.Logtype typeLog, string request, string response)
        {
            try
            {
                var loggerEntity = new Logger()
                {
                    Type = (int)typeLog, 
                    Message = msg,
                    Request = request,
                    Response = response,
                    Date = DateTime.Now
                };

                logger.Add(loggerEntity);
            }
            catch (Exception)
            {
            }
        }
    }
}
