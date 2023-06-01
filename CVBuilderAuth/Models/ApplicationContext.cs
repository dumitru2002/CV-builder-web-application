using Microsoft.EntityFrameworkCore;

namespace CVBuilderAuth.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserCvInfo> UserCvInfos { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public ApplicationContext()
        {
        }
    }
}
