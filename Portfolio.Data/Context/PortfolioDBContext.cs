using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Configurations;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Context
{
    public class PortfolioDBContext : IdentityDbContext<ApplicationUser>
    {
        public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options) { }

        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            //modelBuilder.ApplyConfiguration(new PersonalInfoConfiguration());
            modelBuilder.Entity<PersonalInfo>().HasData(

                new PersonalInfo()
                {
                    Id = 1,
                    Name = "Omar Bin Modied",
                    Email = "omar.binmodied.1@gmail.com",
                    Phone = "33807432",
                    Address = "456 Elm St",
                    Bio = ".net Core Developer",
                    About = "pationate to continuse learning ",
                    ImageUrl = null,

                }

              );

            modelBuilder.Entity<Achievement>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Achievements)
                .HasForeignKey(p => p.CompanyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Achievement>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Achievements)
                .HasForeignKey(p => p.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Achievement>()
            //    .HasCheckConstraint("CHK_Project_CompanyOrClient", "(CompanyId IS NOT NULL AND CustomerId IS NULL) OR (CustomerId IS NOT NULL AND CompanyId IS NULL)");


        }

    }
}
