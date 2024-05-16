using IAO.Models.ApplicantUser;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IAO.Models
{
    public class IAODbContext : DbContext
    {
        public IAODbContext() : base("IAODbContext") { }

        public DbSet<UserApplicant> UserApplicants { get; set; }
        public DbSet<SchoolBackground> SchoolBackgrounds { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for the OfficeAssignment
            modelBuilder.Entity<SchoolBackground>()
                .HasKey(t => t.UserId);

            // Map one-to-zero or one relationship
            modelBuilder.Entity<SchoolBackground>()
                .HasRequired(t => t.UserApplicant)
                .WithOptional(t => t.SchoolBackground);
        }

        public System.Data.Entity.DbSet<IAO.Models.UserApplicant> UserApplicantRecords { get; set; }

        public System.Data.Entity.DbSet<IAO.Models.ApplicantUser.SchoolBackground> SchoolBackgroundRecords { get; set; }
    }
}