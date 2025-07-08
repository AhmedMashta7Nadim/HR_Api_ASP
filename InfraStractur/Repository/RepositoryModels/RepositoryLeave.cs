using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Model;
using Models.Summary;

namespace InfraStractur.Repository.RepositoryModels
{
    public class RepositoryLeave : RepositoryModel<Leave, LeaveSummary, LeaveDTO>
    {
        private readonly HR_Connect context;
        private readonly IMapper mapper;

        public RepositoryLeave(
            HR_Connect context,
            IMapper mapper
            ) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<object> isExistEmpId(LeaveObject leaveObject)
        {
            var IsExist =
                await context.accounts
                .FirstOrDefaultAsync
                (x => x.UserName == leaveObject.EmployeeId);
            if (IsExist == null)
            {
                return null;
            }
           var ixestDay= await getAllDate(IsExist.EmployeeId, leaveObject.StartDate, leaveObject.EndDate);
           if(ixestDay == false)
            {
                return "No";
            }
            //var y = Guid.Parse(leaveObject.EmployeeId
            leaveObject.EmployeeId = IsExist.EmployeeId.ToString();
            Guid qqw = Guid.Parse(leaveObject.EmployeeId);
            //qqw = IsExist.EmployeeId;
            //Guid.Parse(leaveObject.EmployeeId) = qqw;
            var mapping = mapper.Map<LeaveDTO>(leaveObject);
            await UploadImage(mapping);
            return mapping;
        }
        public async Task<string> UploadImage(LeaveDTO leaveDTO)
        {
            //var IsExist =
            //    await context.accounts
            //    .FirstOrDefaultAsync
            //    (x => x.UserName == leaveDTO.EmployeeId.ToString());
            //if (IsExist == null)
            //{
            //    return null;
            //}

            //leaveDTO.EmployeeId = IsExist.EmployeeId;

            var mapping = mapper.Map<Leave>(leaveDTO);

            if (leaveDTO == null || leaveDTO.File.Length == 0)
                return "No file selected.";




            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(wwwRootPath))
                Directory.CreateDirectory(wwwRootPath);
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(mapping.File.FileName);
            string filePath = Path.Combine(wwwRootPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await mapping.File.CopyToAsync(stream);
            }
            string imageUrl = $"/uploads/{uniqueFileName}";
            mapping.Path = imageUrl;

            await context.leaves.AddAsync(mapping);
            await context.SaveChangesAsync();
            return imageUrl;
        }

        public async Task<List<LeaveSummary>> getWithLeavelDate()
        {
            var get = await context.leaves.Where(x =>
            x.EndDate > DateTime.UtcNow
            && x.IsState == true
            && x.IsActive == true).ToListAsync();
            var mapping = mapper.Map<List<LeaveSummary>>(get);
            return mapping;
        }

        public async Task<bool> getAllDate(Guid id, DateTime start, DateTime end)
        {

            var get = await context.employees
                            .Include(x => x.leaves.Where(x => x.IsActive == true))
                            .FirstOrDefaultAsync(x => x.Id == id);

            var length = get.leaves.Sum(x => x.AllDates_e);
            TimeSpan s_e = end - start;
            var sum = length + s_e.Days > 20 ? false : true;
            return sum;
        }
    }
}
