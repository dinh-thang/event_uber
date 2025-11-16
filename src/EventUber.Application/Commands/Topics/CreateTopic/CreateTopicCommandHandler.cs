using EventUber.Application.Abstractions.Repositories;
using EventUber.Domain.Entities;
using MediatR;

namespace EventUber.Application.Commands.Topics.CreateTopics
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, Guid>
    {
        private readonly IRepository<Topic> _topicRepo;
        
        public CreateTopicCommandHandler(IRepository<Topic> topicRepo)
        {
            _topicRepo = topicRepo;
        }
        
        public async Task<Guid> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            Topic newTopic = new Topic(
                request.name,
                request.description,
                request.tenantId
            );

            await _topicRepo.CreateAsync(newTopic);

            return newTopic.Id;
        }
    }
}