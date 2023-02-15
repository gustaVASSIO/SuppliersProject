using Microsoft.EntityFrameworkCore;
using SuppliersProject.Models;

namespace SuppliersProject.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option):
            base(option)
        {
        }     
           public DbSet<Supplier> Supplier { get; set; }
    }
}
