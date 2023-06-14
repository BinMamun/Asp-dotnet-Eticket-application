using ETicket_Application.Data.Base;
using ETicket_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServicesInterface
{
    public interface IProducersService : IEntityBaseRepository<Producer>
    {
    }
}
