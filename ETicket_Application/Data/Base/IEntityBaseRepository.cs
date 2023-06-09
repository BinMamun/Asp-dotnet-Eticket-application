﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETicket_Application.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includePropeties);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task EditAsync(int id, T entity);
        Task DeleteAsync(int id);
        
    }
}
