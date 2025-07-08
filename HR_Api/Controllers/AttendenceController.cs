using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfraStractur.Repository.GenericRepository;
using Models.Model;
using Models.DTO;
using Models.Summary;
using Microsoft.AspNetCore.JsonPatch;
using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Authorization;

namespace HR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private readonly RepositoryAttendence repo;
        private readonly RepositoryEmployee repo_Emp;

        public AttendenceController(
            RepositoryAttendence repo,
            RepositoryEmployee repo_emp
            )
        {
            this.repo = repo;
            repo_Emp = repo_emp;
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpGet]
        public async Task<ActionResult<List<AttendenceSummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<AttendenceSummary>();
            return Ok(list);
        }

        [HttpGet("getWithDate")]
        public async Task<ActionResult<object>> GetAsyncAttendence()
        {
            var get = await repo.GetAsyncAttendenceSummary(DateTime.UtcNow);

            var get_emp = new List<EmployeeSummary>();
            foreach (var item in get)
            {
                var emp = await repo_Emp.GetAsyncId<EmployeeSummary>(item.EmployeeId);
                get_emp.Add(emp);
            }

            var result = new
            {
                attendances = get,
                employees = get_emp
            };

            return Ok(result);
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpGet("getLengthAttends")]
        public async Task<ActionResult<int>> getLengthAttendas()
        {
            var len= await repo.getLength();
            return Ok(len);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendenceDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<AttendenceDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr,Permanent,User")]
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] AttendenceDTO data)
        {
            await repo.AddData(data);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<AttendenceDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            await repo.UpdateData(id, patchDoc);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpPatch("softdelete/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            await repo.SoftDelete(id);
            return Ok();
        }
    }
}
