using Demo.Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace Demo.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>, IAuditable
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
