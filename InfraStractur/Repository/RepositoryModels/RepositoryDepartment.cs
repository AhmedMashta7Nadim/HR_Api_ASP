using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Model;
using Models.Summary;

namespace InfraStractur.Repository.RepositoryModels
{
    public class RepositoryDepartment : RepositoryModel<Department, DepartmentSummary, DepartmentDTO>
    {
        private readonly HR_Connect context;

        public RepositoryDepartment(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
        }

        public async Task<int> getLength_departmint()
        {
            var getLength = await context.departments.ToListAsync();
            return getLength.Count;
        }

        public async Task<List<Department>> getListEmp()
        {
            var getEmp = await context.departments.
                Include(x=>x.employees)
                .ToListAsync();
            return getEmp;
        }

        public async Task<Department> GetDepartmentAsnListEmployee(Guid guid)
        {
            var get=await context.departments
                .Include(x => x.employees)
                .FirstOrDefaultAsync(x=>x.Id==guid);

            if (get == null)
            {
                return null;

            }
            return get;
        }

    }
}
