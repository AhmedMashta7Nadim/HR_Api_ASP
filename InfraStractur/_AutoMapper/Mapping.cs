using AutoMapper;
using Models.DTO;
using Models.Model;
using Models.Summary;

namespace InfraStractur._AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeSummary>().ReverseMap();

            CreateMap<Salary, SalaryDTO>().ReverseMap();
            CreateMap<Salary, SalarySummary>().ReverseMap();

            CreateMap<Leave, LeaveDTO>().ReverseMap();
            CreateMap<Leave, LeaveSummary>().ReverseMap();

            CreateMap<Evaluation, EvaluationDTO>().ReverseMap();
            CreateMap<Evaluation, EvaluationSummary>().ReverseMap();

            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Department, DepartmentSummary>().ReverseMap();

            CreateMap<Attendence, AttendenceDTO>().ReverseMap();
            CreateMap<Attendence, AttendenceSummary>().ReverseMap();

            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, AccountSummary>().ReverseMap();
        }
    }
}
