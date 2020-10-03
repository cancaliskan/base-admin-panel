using System;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public Role Role { get; set; }
    }
}