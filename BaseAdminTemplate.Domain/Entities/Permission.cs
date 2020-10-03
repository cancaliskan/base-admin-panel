namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Permission : BaseEntity
    {
        public Role Role { get; set; }
        public Menu Menu { get; set; }
    }
}