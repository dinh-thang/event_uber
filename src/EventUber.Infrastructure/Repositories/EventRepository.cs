using EventUber.Application.Abstractions.Repositories;
using EventUber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventUber.Infrastructure.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;    
        }

        public async Task CreateAsync(Event entity)
        {
            await _context.Events.AddAsync(entity).AsTask();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Events.FirstOrDefaultAsync<Event>(x => x.Id == id);

            if (e is null)
            {
                throw new KeyNotFoundException($"Couldn't find Event with id: {id}.");
            }

            _context.Remove(e);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events
                    .AsNoTracking()
                    .OrderBy(e => e.CreatedAt)
                    .ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(Guid id)
        {
            return await _context.Events
                    .AsNoTracking()
                    .FirstOrDefaultAsync<Event>(e => e.Id == id); 
        }

        public async Task UpdateAsync(Event entity)
        {
            throw new NotImplementedException("Event are not allow to be update");
        }
    }
}