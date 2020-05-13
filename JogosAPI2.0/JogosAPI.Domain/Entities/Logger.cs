using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Domain.Entities
{
    public class Logger : BaseEntity
    {
        public int Type { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
