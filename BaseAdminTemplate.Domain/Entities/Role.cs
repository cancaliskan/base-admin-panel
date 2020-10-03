namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}