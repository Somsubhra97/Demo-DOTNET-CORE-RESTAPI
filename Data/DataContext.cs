using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        
        public DbSet<Command> Commands { get; set; }//
        
     }
}