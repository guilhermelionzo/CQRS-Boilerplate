using System;

namespace PROJECT_NAME.Domain.ExternalServices
{
    public interface IDateTimeProvider
    {
        public DateTime DateTimeNow { get; }
    }
}