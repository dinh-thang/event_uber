using MediatR;

namespace EventUber.Application.Commands.Topics.CreateTopics
{
    public record CreateTopicCommand(
        string name,
        string description,
        Guid tenantId
    ) : IRequest<Guid> {}
}