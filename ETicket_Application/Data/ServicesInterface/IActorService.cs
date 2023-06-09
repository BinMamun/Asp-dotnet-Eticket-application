using ETicket_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServicesInterface
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActors();
        Actor ActorById(int id);
        void Create(Actor actor);
        Actor Edit(int id, Actor actor);
        void Delete(int id);
    }
}
