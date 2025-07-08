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
    public class DepartmentController : ControllerBase
    {
        private readonly RepositoryDepartment repo;

        public DepartmentController(RepositoryDepartment repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentSummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<DepartmentSummary>();
            return Ok(list);
        }
        [Authorize(Roles = "Admin,Hr,Permanent,User")]
        [HttpGet("getAndList")]
        public async Task<ActionResult<List<Department>>> GetAllAndList()
        {
            var list = await repo.getListEmp();

            return Ok(list);
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpGet("getDepartmintLength")]
        public async Task<ActionResult<int>> getLengthDepartmint()
        {
            var getDepartmintCount = await repo.getLength_departmint();
            return getDepartmintCount;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<DepartmentDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr,Permanent,User")]
        [HttpGet("getDepartmentAsnListEmployee/{id}")]
        public async Task<ActionResult<Department>> GetDepartmentAsnListEmployee(Guid id)
        {
            var item = await repo.GetDepartmentAsnListEmployee(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] DepartmentDTO data)
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
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<DepartmentDTO> patchDoc)
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
