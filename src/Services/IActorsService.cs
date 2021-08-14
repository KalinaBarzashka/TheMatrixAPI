using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMatrixAPI.Models.Actor;

namespace TheMatrixAPI.Services
{
    public interface IActorsService
    {
        public bool DoesActorExist(int id);

        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(int id);

        public void Add(AddActorViewModel actorData);

        public void Edit(int id, EditActorViewModel actorData);

        public void DeleteById(int id);
    }
}
