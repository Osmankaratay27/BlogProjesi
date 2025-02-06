using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-56OJ44O; database=CoreBlogApiDb; integrated security=true;TrustServerCertificate=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
