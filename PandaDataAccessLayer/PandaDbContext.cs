using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Entities.Checklists;
using PandaDataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PandaDataAccessLayer
{
    public class PandaDbContext : DbContext
    {
        //Users
        public DbSet<UserBase> Users { get; set; }
        public DbSet<EmployerUser> EmployerUsers { get; set; }
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<PrivateEmployer> PrivateEmployers { get; set; }
        public DbSet<PrivateRecruiter> PrivateRecruiters { get; set; }
        //Checklists
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<EmployerChecklist> EmployerChecklists { get; set; }
        //Attributes
        public DbSet<Attrib> Attribs { get; set; }
        public DbSet<AttribType> AttribTypes { get; set; }
        public DbSet<Attrib2Checklist> Attrib2Checklist { get; set; }
        //Dict
        public DbSet<DictGroup> DictGroups { get; set; }
        public DbSet<DictValue> DictValues { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //users mapping
            modelBuilder.Entity<UserBase>().ToTable(typeof(UserBase).Name);
            modelBuilder.Entity<EmployerUser>().ToTable(typeof(EmployerUser).Name);
            modelBuilder.Entity<CompanyMember>().ToTable(typeof(CompanyMember).Name);
            modelBuilder.Entity<PrivateEmployer>().ToTable(typeof(PrivateEmployer).Name);
            modelBuilder.Entity<PrivateRecruiter>().ToTable(typeof(PrivateRecruiter).Name);
            //checklist mapping
            modelBuilder.Entity<Checklist>().ToTable(typeof(Checklist).Name);
            modelBuilder.Entity<EmployerChecklist>().ToTable(typeof(EmployerChecklist).Name);
        }
    }
}
