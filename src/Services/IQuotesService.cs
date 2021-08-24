namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;
    using TheMatrixAPI.Models.Quote;

    public interface IQuotesService
    {
        public bool DoesQuoteExist(int id);

        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);

        public void Add(AddQuoteViewModel quoteData);
    }
}
