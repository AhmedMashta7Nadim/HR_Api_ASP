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
    public class RepositoryDepartment : RepositoryModel<Department, DepartmentSummary, DepartmentDTO>
    {
        public RepositoryDepartment(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
