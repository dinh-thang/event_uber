using EventUber.Application.Abstractions.Repositories;
using EventUber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventUber.Infrastructure.Repositories
{
    public class SubscriptionRepository : IRepository<Subscription>
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;    
        }

        public async Task CreateAsync(Subscription entity)
        {
            await _context.Subscriptions.AddAsync(entity).AsTask();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Subscriptions.FirstOrDefaultAsync<Subscription>(x => x.Id == id);

            if (e is null)
            {
                throw new KeyNotFoundException($"Couldn't find Subscription with id: {id}.");
            }

            _context.Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions
                    .AsNoTracking()
                    .OrderBy(e => e.CreatedAt)
                    .ToListAsync();
        }

        public async Task<Subscription?> GetByIdAsync(Guid id)
        {
            return await _context.Subscriptions
                    .AsNoTracking()
                    .FirstOrDefaultAsync<Subscription>(e => e.Id == id); 
        }

        public async Task UpdateAsync(Subscription entity)
        {
            var sub = await _context.Subscriptions.FirstOrDefaultAsync<Subscription>(s => s.Id == entity.Id);

            if (sub is null)
            {
                throw new KeyNotFoundException($"Couldn't find Subscription with id: {entity.Id}.");
            }

            sub.Type = entity.Type;
            sub.IsActive = entity.IsActive;

            _context.Subscriptions.Update(sub);
            await _context.SaveChangesAsync();
        }
    }
}