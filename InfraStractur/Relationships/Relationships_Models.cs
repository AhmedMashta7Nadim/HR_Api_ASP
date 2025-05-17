using System.Reflection.Emit;
using InfraStractur.Data;
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


        public static async Task SeedUser(ModelBuilder modelBuilder)
        {
            var empId = Guid.Parse("d3d4359a-0036-483b-bf10-59d1a0833870");
            var accountId = Guid.Parse("d3d4359a-0036-483b-bf10-59d1a0833871");
            var dep = Guid.Parse("d3d4359a-0036-483b-bf10-59d1a0833872");

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DepartmentName = "x",
                Type_Departmint = Models.enum_class.Enum_Departmint.HR,
                Id = dep
            });
           

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = empId,
                FirstName = "محمد",
                LastName = "الزهير",
                IsActive = true,
                Position = "مدير موارد بشرية",
                MiddleName = "علي",
                AccountId = accountId,
                AddedEmployee=new DateTime(1/1/1998),
             
                DepartmentId= dep,
            });
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Password = "xxx",
                Role = Models.enum_class.Enum_RoleEmployee.Admin,
                UserName = "xxx",
                Id = accountId,
                EmployeeId= empId
            });
        }

    }
}
