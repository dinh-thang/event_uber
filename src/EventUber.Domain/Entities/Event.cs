using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace EventUber.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public JsonDocument Data { get; set; } = JsonDocument.Parse("{}");

        public Guid TopicId { get; private set; }
        public Topic Topic { get; set; } = null!;

        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; set; } = null!;

        public Event(JsonDocument data, Guid topicId, Guid tenantId)
        {
            Data = data;
            TopicId = topicId;
            TenantId = tenantId;
        }

        private Event() {}
    }
}