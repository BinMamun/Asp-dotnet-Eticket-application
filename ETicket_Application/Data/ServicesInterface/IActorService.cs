using ETicket_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServicesInterface
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task <Actor> ActorByIdAsync(int id);
        Task CreateAsync(Actor actor);
        Task<Actor> EditAsync(int id, Actor actor);
        Task DeleteAsync(int id);
    }
}
