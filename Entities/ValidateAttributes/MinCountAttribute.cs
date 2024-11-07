using System.ComponentModel.DataAnnotations;

namespace Entities.ValidateAttributes
{
    public class MinCountAttribute : ValidationAttribute
    {
        private readonly int _minCount;
        public MinCountAttribute(int minCount)
        {
            _minCount = minCount;
            ErrorMessage = $"At least {_minCount} characters required!";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collection = value as ICollection<string>;
            if (collection == null || collection.Count < _minCount)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
