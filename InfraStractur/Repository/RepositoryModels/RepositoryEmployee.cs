using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Migrations;
using InfraStractur.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Model;
using Models.Summary;

namespace InfraStractur.Repository.RepositoryModels
{
    public class RepositoryEmployee : RepositoryModel<Employee, EmployeeSummary, EmployeeDTO>
    {
        private readonly HR_Connect context;

        public RepositoryEmployee(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
        }

        public async Task<int> getLengthEmployee()
        {
            var getLength = await context.employees.ToListAsync();
            return getLength.Count;
        }

        public async Task<Employee> getAndList(Guid id)
        {
            var get = await context.employees
                .Include(x => x.salarys)
                .Include(x => x.evaluations)
                .Include(x => x.attendences)
                .Include(x => x.leaves)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(get is null)
            {
                return null;
            }
            return get;
           
        }

    }
}
