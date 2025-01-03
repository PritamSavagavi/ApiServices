using ApiServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApiServices.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions options) : base(options)
       {
        
       }
       public DbSet<AppUser>? Users { get; set; }
    }
}