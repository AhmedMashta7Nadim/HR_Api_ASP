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
    public class RepositoryAccount : RepositoryModel<Account, AccountSummary, AccountDTO>
    {
        private readonly HR_Connect context;
        private readonly IMapper mapper;

        public RepositoryAccount(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<(TResult,VResult)> 
            getEmolyeeWithAccount<TResult, VResult>(Guid Idemp)
        {
            var getAccount = await context.accounts.FirstOrDefaultAsync(x => x.EmployeeId == Idemp);
            if (getAccount != null)
            {
                var getEmp = await context.employees.FirstOrDefaultAsync(x => x.Id == Idemp);
                var mappingwithAccoumt = mapper.Map<TResult>(getAccount);
                var mappingwithAccoumt2 = mapper.Map<VResult>(getEmp);
                return (mappingwithAccoumt, mappingwithAccoumt2);
            }
            return default;
        }

    }
}
