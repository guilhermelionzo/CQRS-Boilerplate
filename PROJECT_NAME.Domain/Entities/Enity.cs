using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace PROJECT_NAME.Domain.Entities
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}