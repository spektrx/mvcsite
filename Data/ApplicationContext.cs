using Microsoft.EntityFrameworkCore;
using mvcsite.Models;


namespace mvcsite.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
