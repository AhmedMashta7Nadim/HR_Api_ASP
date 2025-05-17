using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractur.Relationships;
using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace InfraStractur.Data
{
    public class HR_Connect:DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Attendence> attendences { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Evaluation> evaluations { get; set; }
        public DbSet<Leave> leaves { get; set; }
        public DbSet<Salary> salarys { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HR_Api_2;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Relationships_Models.ModelRelation(modelBuilder);
        }





    }
}
