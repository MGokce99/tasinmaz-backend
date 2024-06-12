using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.API.Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=GokceTasinmaz;User Id=postgres;Password=12345;");
        }

      
        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<Parsel> Tasinmazlar { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Il> Il { get; set; }

        public DbSet<Ilce> Ilce { get; set; }

        public DbSet<Mahalle> Mahalle { get; set; }

        public DbSet<Log> Log { get; set; }
        public static object Blogs { get; internal set; }
    }
}
