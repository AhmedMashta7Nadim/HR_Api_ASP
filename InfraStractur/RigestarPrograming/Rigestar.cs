using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractur.Repository.GenericRepository;
using InfraStractur.Repository.RepositoryModels;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStractur.RigestarPrograming
{
    public static class Rigestar
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<RepositoryEmployee>();
            services.AddScoped<RepositoryAttendence>();
            services.AddScoped<RepositorySalary>();
            services.AddScoped<RepositoryEvaluation>();
            services.AddScoped<RepositoryDepartment>();
            services.AddScoped<RepositoryAccount>();
            services.AddScoped<RepositoryLeave>();

        }
    }
}
