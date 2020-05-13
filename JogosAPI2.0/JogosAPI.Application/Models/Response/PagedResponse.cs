using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Application.Models.Response
{
    public class PagedResponse<T>
    {
        public PagedResponse()
        {
            Total = ListData?.Count ?? 0;
            TotalPage = ListData?.Count ?? 0;
            CurrentPage = 1;
        }
        public int Total { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public List<T> ListData { get; set; }
    }
}
