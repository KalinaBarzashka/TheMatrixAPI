﻿namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;
    using TheMatrixAPI.Models.Character;
    using TheMatrixAPI.Models.DTO.Character;

    public interface ICharactersService
    {
        public IEnumerable<T> GetAll<T>();

        public CharactersGroups GetAllGroups();

        public T GetById<T>(int id);

        public bool IsCharacterAvailable(int actorId, int characterId);

        public bool DoesCharacterExist(int characterId);

        public void Add(AddCharacterViewModel characterData);

        public void Edit(int characterId, EditCharacterViewModel characterData);

        public void DeleteById(int characterId);
    }
}
