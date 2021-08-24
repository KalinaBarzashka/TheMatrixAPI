namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;

    public interface IQuotesService
    {
        public bool DoesQuoteExist(int id);

        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);
    }
}
