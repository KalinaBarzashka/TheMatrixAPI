namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;

    public interface ICharactersService
    {
        public IEnumerable<T> GetAll<T>();
    }
}
