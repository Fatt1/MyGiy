using Domain.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Entities.Task> Tasks { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker
                .Entries<AggreateRoot>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            var domainEvents = domainEntities.
                SelectMany(x => x.DomainEvents)
                .ToList();

            var result = await base.SaveChangesAsync();

            foreach (var domainEvent in domainEvents)
            {
                Console.WriteLine($"[Event Published]: {domainEvent.GetType().Name}");
                await _mediator.Publish(domainEvent);
            }

            domainEntities.ForEach(entity => entity.ClearDomainEvents());
            return result;

        }
    }
}
