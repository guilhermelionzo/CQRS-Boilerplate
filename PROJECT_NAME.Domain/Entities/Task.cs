using System;
using Flunt.Validations;

namespace PROJECT_NAME.Domain.Entities
{
    public class Task : Entity, IValidatable
    {
        public Task() { }
        public Task(string name)
        {
            Name = name;
            Status = ETaskStatus.Created;
            StartDate = new DateTime();
            FinishDate = new DateTime();
        }

        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public ETaskStatus Status { get; private set; }

        public void Start(DateTime dateTime)
        {
            StartDate = dateTime;
            Status = ETaskStatus.Started;
        }

        public void Stop()
        {
            Status = ETaskStatus.Stopped;
        }
        public void Resume()
        {
            Status = ETaskStatus.Resumed;
        }

        public void Finish(DateTime dateTime)
        {
            FinishDate = dateTime;
            Status = ETaskStatus.Finished;
        }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                .IsNotNullOrEmpty(Name, "Name", "Task name cannot be null or empty")
            );
        }
    }
}