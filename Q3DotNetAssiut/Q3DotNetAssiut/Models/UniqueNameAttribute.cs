using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Q3DotNetAssiut.Models
{
    public class UniqueNameAttribute<T> : ValidationAttribute where T : class
    {
        private readonly string _propertyName;

        public UniqueNameAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newValue = value.ToString();
            var context = (ITIContext)validationContext.GetService(typeof(ITIContext));

            var dbSet = context.Set<T>();

            bool exists = dbSet
                .AsQueryable()
                .Any(e => EF.Property<string>(e, _propertyName) == newValue);
            if (exists)
            {
                return new ValidationResult($"{_propertyName} Must Be Unique");
            }
            return ValidationResult.Success;
        }
    }
}
