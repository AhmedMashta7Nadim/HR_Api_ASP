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
    public class RepositoryLeave : RepositoryModel<Leave, LeaveSummary, LeaveDTO>
    {
        public RepositoryLeave(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
