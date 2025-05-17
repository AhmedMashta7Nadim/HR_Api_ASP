using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.GenericRepository;
using Models.DTO;
using Models.Model;
using Models.Summary;

namespace InfraStractur.Repository.RepositoryModels
{
    public class RepositoryEmployee : RepositoryModel<Employee, EmployeeSummary, EmployeeDTO>
    {
        public RepositoryEmployee(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
