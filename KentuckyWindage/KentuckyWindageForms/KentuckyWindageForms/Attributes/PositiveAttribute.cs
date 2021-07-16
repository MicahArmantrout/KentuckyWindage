using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KentuckyWindageForms.Attributes
{ public class PositiveAttribute : ValidationAttribute
    {
        public PositiveAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (decimal)value > 0m 
                ? ValidationResult.Success 
                : new ValidationResult("Value must be greater than 0");
        }
    }
}
