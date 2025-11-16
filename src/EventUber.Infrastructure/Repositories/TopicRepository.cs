using EventUber.Application.Abstractions.Repositories;
using EventUber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventUber.Infrastructure.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;    
        }

        public async Task CreateAsync(Topic entity)
        {
            await _context.Topics.AddAsync(entity).AsTask();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Topics.FirstOrDefaultAsync<Topic>(x => x.Id == id);

            if (e is null)
            {
                throw new KeyNotFoundException($"Couldn't find Topic with id: {id}.");
            }

            _context.Remove(e);
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            return await _context.Topics
                    .AsNoTracking()
                    .OrderBy(e => e.CreatedAt)
                    .ToListAsync();
        }

        public async Task<Topic?> GetByIdAsync(Guid id)
        {
            return await _context.Topics
                    .AsNoTracking()
                    .FirstOrDefaultAsync<Topic>(e => e.Id == id); 
        }

        public async Task UpdateAsync(Topic entity)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync<Topic>(t => t.Id == entity.Id);

            if (topic is null)
            {
                throw new KeyNotFoundException($"Couldn't find Topic with id: {entity.Id}.");
            }

            topic.Name = entity.Name;
            topic.Description = entity.Description;

            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
        }
    }
}