using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class FCRelationRepository : GenericRepository<FCRelation>
    {
        public FCRelationRepository(DbContext db)
            : base(db) { }
    }
}
