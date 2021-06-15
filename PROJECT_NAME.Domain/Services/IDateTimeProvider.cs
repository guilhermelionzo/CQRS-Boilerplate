using System;

namespace PROJECT_NAME.Domain.Services
{
    public interface IDateTimeProvider
    {
        public DateTime DateTimeNow { get; }
    }
}