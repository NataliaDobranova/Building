using Db.Model;
using System;
using System.Data.Entity;

namespace Db
{
    public class BuildingContext : DbContext
    {
        public BuildingContext(string connectionString)
               : base(connectionString)
        {

        }
        public BuildingContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
