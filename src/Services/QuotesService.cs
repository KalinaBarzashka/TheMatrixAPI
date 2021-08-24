namespace TheMatrixAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TheMatrixAPI.Data;

    public class QuotesService : IQuotesService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public QuotesService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public bool DoesQuoteExist(int id)
        {
            return this.dbContext.Quotes.Any(x => x.Id == id);
        }

        public IEnumerable<T> GetAll<T>()
        {
            var quotes = dbContext.Quotes
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();

            return quotes;
        }

        public T GetById<T>(int id)
        {
            var quote = dbContext.Quotes
               .Where(x => x.Id == id)
               .ProjectTo<T>(this.mapper.ConfigurationProvider)
               .FirstOrDefault();

            return quote;
        }
    }
}
