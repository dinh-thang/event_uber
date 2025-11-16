using EventUber.Application.Abstractions.Repositories;
using EventUber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventUber.Infrastructure.Repositories
{
    public class TenantRepository : IRepository<Tenant>
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;    
        }

        public async Task CreateAsync(Tenant entity)
        {
            await _context.Tenants.AddAsync(entity).AsTask();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Tenants.FirstOrDefaultAsync<Tenant>(x => x.Id == id);

            if (e is null)
            {
                throw new KeyNotFoundException($"Couldn't find Tenant with id: {id}.");
            }

            _context.Remove(e);
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants
                    .AsNoTracking()
                    .OrderBy(e => e.CreatedAt)
                    .ToListAsync();
        }

        public async Task<Tenant?> GetByIdAsync(Guid id)
        {
            return await _context.Tenants
                    .AsNoTracking()
                    .FirstOrDefaultAsync<Tenant>(e => e.Id == id); 
        }

        public async Task UpdateAsync(Tenant entity)
        {
            var tenant = await _context.Tenants.FirstOrDefaultAsync<Tenant>(t => t.Id == entity.Id);

            if (tenant is null)
            {
                throw new KeyNotFoundException($"Couldn't find Tenant with id: {entity.Id}.");
            }

            tenant.Name = entity.Name;

            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }
    }
}