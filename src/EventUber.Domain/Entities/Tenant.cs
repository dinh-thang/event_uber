namespace EventUber.Domain.Entities
{
    public class Tenant 
    {
        public Guid Id { get; private set; } = Guid.NewGuid(); 
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public string Name { get; set; } = "";

        public Tenant(string name, string email)
        {
            Name = name;
        }

        private Tenant() {}
    }    
}

