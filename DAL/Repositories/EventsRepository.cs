using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class EventsRepository : GenericRepository<Events>
    {
        public EventsRepository(DbContext db)
            : base(db) { }
    }
}
