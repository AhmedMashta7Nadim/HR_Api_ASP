using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace InfraStractur.Relationships
{
    public class Relationships_Models
    {
        public static void ModelRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
             .HasOne(d => d.Department)
             .WithMany(e => e.employees)
             .HasForeignKey(d => d.DepartmentId);


            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Employee)
                .WithMany(ev => ev.evaluations)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<Leave>()
              .HasOne(e => e.Employee)
              .WithMany(le => le.leaves)
              .HasForeignKey(e => e.EmployeeId);

            //modelBuilder.Entity<Salary>()
            // .HasOne(e => e.Employee)
            // .WithMany(s => s.salarys)
            // .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<Salary>()
           .HasOne(e => e.Employee)
           .WithMany(s => s.salarys)
           .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Employee)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(a => a.EmployeeId);

        }
    }
}
