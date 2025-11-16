namespace EventUber.Domain.Entities
{
    public class Topic 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;


        public Topic(string name, string description, Guid tenantId)
        {
            Name = name;
            Description = description;
            TenantId = tenantId;
        }

        private Topic() {}
    }
}
