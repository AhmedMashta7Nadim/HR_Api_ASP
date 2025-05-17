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

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<DepartmentDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] DepartmentDTO data)
        {
            await repo.AddData(data);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<DepartmentDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            await repo.UpdateData(id, patchDoc);
            return Ok();
        }

        [HttpPatch("softdelete/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            await repo.SoftDelete(id);
            return Ok();
        }
    }
}
