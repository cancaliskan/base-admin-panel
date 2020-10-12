using System;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class PasswordReset : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Key { get; set; }
    }
}