using System;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Granamiza.Shared
{
    public class Model
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; set; }

        public Model ()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
        }

        public bool Valid { get; private set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }

        public void Validate<T> (T entity, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(entity);
            Valid = ValidationResult.IsValid;
        }
    }
}
