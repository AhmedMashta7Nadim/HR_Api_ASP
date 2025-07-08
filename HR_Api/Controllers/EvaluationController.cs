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
    public class EvaluationController : ControllerBase
    {
        private readonly RepositoryEvaluation repo;

        public EvaluationController(RepositoryEvaluation repo)
        {
            this.repo = repo;
        }
        [Authorize(Roles = "Admin,Hr,Permanent,Users")]
        [HttpGet]
        public async Task<ActionResult<List<EvaluationSummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<EvaluationSummary>();
            return Ok(list);
        }
        [Authorize(Roles = "Admin,Hr,Permanent,Users")]
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<EvaluationDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr,Permanent")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EvaluationDTO data)
        {
            await repo.AddData(data);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr,Permanent")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await repo.Delete(id);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr,Permanent")]
        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<EvaluationDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            await repo.UpdateData(id, patchDoc);
            return Ok();
        }
        [Authorize(Roles = "Admin,Hr,Permanent")]
        [HttpPatch("softdelete/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            await repo.SoftDelete(id);
            return Ok();
        }
    }
}
