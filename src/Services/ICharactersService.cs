namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;

    public interface ICharactersService
    {
        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);

        public bool IsCharacterAvailable(int actorId, int characterId);
    }
}
