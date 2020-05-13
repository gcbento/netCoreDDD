using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;

namespace JogosAPI.Infra.Data.Repositories
{
    public class LoggerRepository : BaseRepository<Logger, LoggerFilter>, ILoggerRepository
    {
        public LoggerRepository(JogosAPIContext context) : base(context)
        {}
    }
}
