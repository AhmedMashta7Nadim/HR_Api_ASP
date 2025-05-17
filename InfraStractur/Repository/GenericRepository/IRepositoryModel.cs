using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace InfraStractur.Repository.GenericRepository
{
    public interface IRepositoryModel<T,V,Z>
        where T : class
        where V : class
        where Z : class
    {
        Task<List<IResult>> GetAsyncAll<IResult>(bool IsSummary);
        Task<IResult> GetAsyncId<IResult>(Guid Id, bool IsSummary);
        Task AddData(Z data);
        Task UpdateData(Guid id, JsonPatchDocument<Z> update);
        Task Delete(Guid Id);
        Task SoftDelete(Guid Id);
    }
}
