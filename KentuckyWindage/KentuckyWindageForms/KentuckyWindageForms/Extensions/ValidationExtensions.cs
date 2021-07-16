using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KentuckyWindageForms.Extensions
{
    public static class ValidationExtensions
    {
        public static bool Validate<T>(this T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

        public static bool IsValid(this object obj)
        {
            return obj.Validate(out _);
        }
    }
}
