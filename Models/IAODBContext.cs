using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IAO.Models.ApplicantUser;
using System.Reflection.Emit;

namespace IAO.Models
{
    public class IAODBContext : DbContext
    {
        public IAODBContext() : base("IAODBContext") 
        { 

        }

        public DbSet<UserApplicant> UserApplicants { get; set; }
        public DbSet<SchoolBackground> SchoolBackgrounds { get; set; }

       
    }
}