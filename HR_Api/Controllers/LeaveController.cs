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
    public class LeaveController : ControllerBase
    {
        private readonly RepositoryLeave repo;

        public LeaveController(RepositoryLeave repo)
        {
            this.repo = repo;
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpGet]
        public async Task<ActionResult<List<LeaveSummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<LeaveSummary>();

            return Ok(list.Where(x =>
                x.IsActive == true && x.IsState == false
            ).ToList());
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpGet("getWithLeavelDate")]
        public async Task<ActionResult<List<LeaveSummary>>> getWithLeavel()
        {
            var get = await repo.getWithLeavelDate();
            return Ok(get);
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpGet("length_leave")]
        public async Task<int> getlength()
        {
            var list = await repo.GetAsyncAll<LeaveSummary>();
            var xx=list.Where(x =>
                x.IsActive == true && x.IsState == false
            );
            return xx.Count();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<LeaveDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr,Permanent,User")]
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] LeaveObject data)
        {
           var result= await repo.isExistEmpId(data);
            return Ok(result);
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
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<LeaveDTO> patchDoc)
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
