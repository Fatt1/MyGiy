using Demo.Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace Demo.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>, IAuditable
    {
        public string Description { get; set; } = null!;
        public string RoleCode { get; set; } = null!;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
