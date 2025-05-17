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
    public class RepositoryEvaluation : RepositoryModel<Evaluation, EvaluationSummary, EvaluationDTO>
    {
        public RepositoryEvaluation(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
