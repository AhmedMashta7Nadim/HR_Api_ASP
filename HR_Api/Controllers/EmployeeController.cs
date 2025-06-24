using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Summary;

namespace HR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RepositoryEmployee repository;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(
            RepositoryEmployee repository,
            ILogger<EmployeeController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<EmployeeSummary>>> GetEmployees([FromQuery] bool isSummary = true)
        {
            var result = await repository.GetAsyncAll<EmployeeSummary>(isSummary);
            return Ok(result);
        }

        // Get employee by ID (summary or full)
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(Guid id, [FromQuery] bool isSummary = true)
        {
            var employee = await repository.GetAsyncId<EmployeeDTO>(id, isSummary);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet("GetEmployeeLength")]
        public async Task<ActionResult<int>> getEmployeeLength()
        {
            var getLength = await repository.getLengthEmployee();
            return getLength;
        }


        // Add new employee
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromForm] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await repository.AddData(employeeDTO);
            return Ok("Employee added successfully.");
        }

        // Delete employee permanently
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                await repository.Delete(id);
                return Ok("Employee deleted successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Soft delete employee (set IsDeleted = true)
        [HttpPatch("soft-delete/{id}")]
        public async Task<ActionResult> SoftDeleteEmployee(Guid id)
        {
            try
            {
                await repository.SoftDelete(id);
                return Ok("Employee soft deleted successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Update employee using PATCH
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] JsonPatchDocument<EmployeeDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest("Invalid patch document.");

            try
            {
                await repository.UpdateData(id, patchDoc);
                return Ok("Employee updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
