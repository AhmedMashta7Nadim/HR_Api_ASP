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
    public class SalaryController : ControllerBase
    {
        private readonly RepositorySalary repo;

        public SalaryController(RepositorySalary repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalarySummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<SalarySummary>();
            var x= list.Where(x=>x.IsReceiveSalary==false);
            return Ok(x);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<SalaryDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] SalaryDTO data)
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
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<SalaryDTO> patchDoc)
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
