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
            :base("Data Source=A104PCPREPOD\\A1PREPOD;Initial Catalog=Egor_N;Integrated Security=SSPI;")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
