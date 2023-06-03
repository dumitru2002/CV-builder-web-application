using Microsoft.EntityFrameworkCore;

namespace CVBuilderAuth.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserCvInfo> UserCvInfos { get; set; } = null!;
        public DbSet<CvExperience> CvExperiences { get; set; }
        public DbSet<CvLanguageSkill> CvLanguageSkills { get; set; }
        public DbSet<CvSkill> CvSkills { get; set; }
        public DbSet<CvEducation> CvEducations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }







        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CvExperience>().HasNoKey();
        }*/
       
       

        public ApplicationContext()
        {
        }
    }
}
