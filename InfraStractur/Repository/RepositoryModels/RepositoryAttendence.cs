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
    public class RepositoryAttendence : RepositoryModel<Attendence, AttendenceSummary, AttendenceDTO>
    {
        private readonly HR_Connect context;
        private readonly IMapper mapper;

        public RepositoryAttendence(HR_Connect context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<AttendenceSummary>> GetAsyncAttendenceSummary(DateTime dateTime) {
            var get = await context.attendences
     .Where(x =>
         x.InDate.Day == dateTime.Day &&
         x.InDate.Month == dateTime.Month &&
         x.InDate.Year == dateTime.Year
     )
     .ToListAsync();

            


            var mapp = mapper.Map<List<AttendenceSummary>>(get);
            return mapp;
        }

        public async Task<int> getLength()
        {

            var len = await context.attendences.Where(x =>
              x.InDate.Day ==  DateTime.UtcNow.Day &&
         x.InDate.Month ==  DateTime.UtcNow.Month &&
         x.InDate.Year ==  DateTime.UtcNow.Year).ToListAsync();


            return len.Count();
        }

    }
}
