using AutoMapper;
using InfraStractur._AutoMapper;
using InfraStractur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Model;

namespace HR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HR_Connect context;
        private readonly IMapper mapper;

        public EmployeeController(
            HR_Connect context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var get = await context.employees.ToListAsync();

            return Ok(get);
        }

        [HttpGet("getEmpId/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(Guid id)
        {
            var employee = await context.employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            var employeeDTO = mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        [HttpPost("addEmp")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee([FromForm] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = mapper.Map<Employee>(employeeDTO);
            await context.employees.AddAsync(employee);
            await context.SaveChangesAsync();

            var createdEmployeeDTO = mapper.Map<EmployeeDTO>(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, createdEmployeeDTO);
        }

    }
}
