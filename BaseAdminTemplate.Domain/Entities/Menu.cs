using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Menu : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}