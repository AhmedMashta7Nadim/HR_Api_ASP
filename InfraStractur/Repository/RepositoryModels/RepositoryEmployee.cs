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

    }
}
