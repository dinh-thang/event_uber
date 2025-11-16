using EventUber.Domain.Enums;

namespace EventUber.Domain.Entities
{
    public class Subscription 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public SubscriptionType Type { get; set; }
        public bool IsActive { get; set; } = true;

        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; set; } = null!;

        public Guid TopicId { get; private set; }
        public Topic Topic { get; set; } = null!;

        public Subscription(SubscriptionType type, bool isActive, Guid tenantId, Guid topicId)
        {
            Type = type;
            IsActive = isActive;
            TenantId = tenantId;
            TopicId = topicId;
        }

        private Subscription() {}
    }
}
