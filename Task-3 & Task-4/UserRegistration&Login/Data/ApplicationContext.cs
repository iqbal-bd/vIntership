using Microsoft.EntityFrameworkCore;
using UserRegistration_Login.Models;

namespace UserRegistration_Login.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
