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
using Auth.Authentication_Models;
using InfraStractur.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace HR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RepositoryAccount repo;
        private readonly ITokenServices token;

        public AccountController(
            RepositoryAccount repo,
            ITokenServices token
            )
        {
            this.repo = repo;
            this.token = token;
        }
        [HttpGet("EmployeeAccount/{Id}")]
        public async Task<ActionResult<(AccountSummary, EmployeeSummary)>> getDataEmployee(Guid Id)
        {
            var request = await repo.getEmolyeeWithAccount<AccountSummary, EmployeeSummary>(Id);
            if (request == default)
            {
                return NotFound();
            }
        object data = new
        {
            Account= request.Item1,
            Employee= request.Item2
        };
            return Ok(data);
        }


        [HttpGet]
        public async Task<ActionResult<List<AccountSummary>>> GetAll()
        {
            var list = await repo.GetAsyncAll<AccountSummary>();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetById(Guid id)
        {
            var item = await repo.GetAsyncId<AccountDTO>(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(Roles = "Admin,Hr")]
        [HttpPost]
        public async Task<ActionResult> Add( AccountDTO data)
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
        public async Task<ActionResult> Update(Guid id, [FromBody] JsonPatchDocument<AccountDTO> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            await repo.UpdateData(id, patchDoc);
            return Ok();
        }
        [HttpPost("LogIn")]
        public async Task<ActionResult> LogIn([FromForm]LogIn logIn)
        {
            var login = await token.GeneretorToken(logIn);
            if(login == null)
            {
                return NotFound();
            }
            return Ok(new { token = login });
        }


        [HttpPatch("softdelete/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            await repo.SoftDelete(id);
            return Ok();
        }

        
    }
}
