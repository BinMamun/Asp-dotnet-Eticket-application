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
        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return await _db.Actors.ToListAsync();
        }
        
        public async Task<Actor> ActorByIdAsync(int id)
        {
            return await _db.Actors.FirstAsync(x => x.ActorId == id);
        }
        public async Task CreateAsync(Actor actor)
        {
            await _db.Actors.AddAsync(actor);
            await _db.SaveChangesAsync();
        }
        public async Task<Actor> EditAsync(int id, Actor actor)
        {
            _db.Update(actor);
            await _db.SaveChangesAsync();
            return actor;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }      
        
    }
}
