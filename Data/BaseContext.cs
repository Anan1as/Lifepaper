using Lifepaper.Models;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Lifepaper.Models;
>>>>>>> 139770b9df4fc21712bc8134c2084cdc23dc0faf

namespace Lifepaper.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
