using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KentuckyWindageForms.Attributes
{ public class PositiveAttribute : ValidationAttribute
    {
        public PositiveAttribute(bool allowZero = false)
        {
        }

        public bool AllowZero { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Declarations
            var dec = 0m;
            bool isValid;

            // Conversions
            if (value is int intVal) dec = intVal;
            if (value is double dblVal) dec = Convert.ToDecimal(dblVal);
            if (value is decimal decVal) dec = decVal;

            if (AllowZero)
                isValid = dec >= 0;
            else
                isValid = dec > 0;

            return isValid
                ? ValidationResult.Success 
                : new ValidationResult($"Value must be >{(AllowZero ? "=" : "")} 0");
        }
    }
}
