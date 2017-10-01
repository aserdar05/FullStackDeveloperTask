using FulStackDeveloperTask.App.Model;
using System.Data.Entity;

namespace FulStackDeveloperTask.App.Database
{

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
