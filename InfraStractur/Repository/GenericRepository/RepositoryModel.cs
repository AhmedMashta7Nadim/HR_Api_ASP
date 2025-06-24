using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractur.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Models.Entitys;

namespace InfraStractur.Repository.GenericRepository
{
    public class RepositoryModel<T, V, Z> : IRepositoryModel<T, V, Z>
        where T : class, EntityInterface
        where V : class
        where Z : class
    {
        private readonly HR_Connect context;
        private readonly IMapper mapper;

        public RepositoryModel(
            HR_Connect context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddData(Z data)
        {
            var mapping = mapper.Map<T>(data);
            var sendRequest=await context.Set<T>().AddAsync(mapping);
            await context.SaveChangesAsync();
            return;
        }

        public async Task Delete(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with Id {id} not found.");
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<IResult>> GetAsyncAll<IResult>(bool IsSummary=true)
        {
            var getAll = await context.Set<T>().ToListAsync();
            if(IsSummary is true)
            {
                var mapping=mapper.Map<List<IResult>>(getAll);

                return mapping;
            }
            var mappingFull = mapper.Map<List<IResult>>(getAll);
            return mappingFull;
        }

        public async Task<IResult> GetAsyncId<IResult>(Guid Id, bool IsSummary=true)
        {
            var getId = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);
            if(getId is null)
            {
                return default;
            }
            if (IsSummary)
            {
                var mapped = mapper.Map<IResult>(getId);
                return mapped;
            }
            var mappedFull = mapper.Map<IResult>(getId);
            return mappedFull;
        }
        public async Task SoftDelete(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with Id {id} not found.");
            }
            var prop = typeof(T).GetProperty("IsActive");
            if (prop == null)
            {
                throw new InvalidOperationException("Entity does not have an 'IsDeleted' property.");
            }
            prop.SetValue(entity, false);
            await context.SaveChangesAsync();
        }
        public async Task UpdateData(Guid id, JsonPatchDocument<Z> patchDoc)
        {
            if (patchDoc == null)
                throw new ArgumentNullException(nameof(patchDoc));
            var entity = await context.Set<T>().FirstOrDefaultAsync(x=>x.Id== id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with Id {id} not found.");
            var dto = mapper.Map<Z>(entity);
            patchDoc.ApplyTo(dto);
            mapper.Map(dto, entity);
            await context.SaveChangesAsync();
        }

    }
}
