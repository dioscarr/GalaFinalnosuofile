using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class GazetteRepository : GenericRepository<Gazette>
    {
        public GazetteRepository(DbContext db)
            : base(db) { }
    }
}
