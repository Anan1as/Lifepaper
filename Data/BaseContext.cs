using Lifepaper.Models;
using Microsoft.EntityFrameworkCore;

namespace Lifepaper.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options): base(options){}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}