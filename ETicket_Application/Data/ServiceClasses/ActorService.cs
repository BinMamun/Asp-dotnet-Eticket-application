using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServiceClasses
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _db;
        public ActorsService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            return await _db.Actors.ToListAsync();
        }
        public Actor ActorById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Edit(int id, Actor actor)
        {
            throw new NotImplementedException();
        }

        
    }
}
