using System.ComponentModel.DataAnnotations;

namespace Demo.Persistence.DependencyInjection.Options
{
    public class SqlServerRetryOptions
    {
        [Required, Range(0, 20)]
        public int MaxRetryCount { get; init; }

        [Required]
        public TimeSpan MaxRetryDelaySeconds { get; init; }

        public int[]? ErrorNumbersToAdd { get; init; }
    }
}
