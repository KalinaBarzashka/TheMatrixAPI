namespace TheMatrixAPI.Services
{
    using System.Collections.Generic;
    using TheMatrixAPI.Models.Race;

    public interface IRacesService
    {
        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);

        public T GetRaceDetailsById<T>(int id);

        public bool DoesRaceExist(int id);

        public bool IsRaceInUse(int id);

        public void Add(AddRaceViewModel raceData);

        public void Edit(int id, EditRaceViewModel raceData);

        public void DeleteById(int id);

    }
}
