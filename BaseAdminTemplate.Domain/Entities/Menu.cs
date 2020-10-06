namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Menu : BaseEntity
    {
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
        public bool DisplayInMenu { get; set; }
    }
}