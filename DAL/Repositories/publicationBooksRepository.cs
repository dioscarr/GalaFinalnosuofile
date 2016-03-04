using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class publicationBooksRepository : GenericRepository<publicationBooks>
    {
        public publicationBooksRepository(DbContext db)
            : base(db) { }
    }
}
