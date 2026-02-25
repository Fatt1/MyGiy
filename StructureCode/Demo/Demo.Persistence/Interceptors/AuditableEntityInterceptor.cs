using Demo.Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;

namespace Demo.Persistence.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditableEntityInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            foreach (var entry in context.ChangeTracker.Entries())
            {

                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete softDeleteEntity)
                {
                    // Thay vì xóa thực sự, chỉ đánh dấu là đã xóa
                    softDeleteEntity.IsDeleted = true;
                    softDeleteEntity.DeletedAt = DateTime.UtcNow;
                    entry.State = EntityState.Modified;

                }


                // Xử lí cho trường hợp entity có thuộc tính ngày tạo, ngày sửa đổi
                if (entry.Entity is IDateTracking dateEntity)
                {
                    var now = DateTime.UtcNow;
                    if (entry.State == EntityState.Added)
                    {
                        dateEntity.CreatedDate = now;
                        dateEntity.ModifiedDate = null;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        dateEntity.ModifiedDate = now;
                    }
                }

                if (entry.Entity is IUserTracking userEntity)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (entry.State == EntityState.Added)
                    {
                        userEntity.CreatedBy = Guid.Parse(userId!);
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        userEntity.ModifiedBy = Guid.Parse(userId!);
                    }
                }
            }
        }
    }
}
