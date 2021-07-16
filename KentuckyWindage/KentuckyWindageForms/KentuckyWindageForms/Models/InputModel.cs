using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KentuckyWindageForms.Models
{
    public class InputModel
    {
        [Range(0.0d, double.PositiveInfinity, ErrorMessage = "The field {0} must be greater than {1}.")] 
        public decimal TargetSizeInches { get; set; }
        [Range(0.0d, double.PositiveInfinity, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal TargetSizeMilDots { get; set; }
        [Range(0.0d, double.PositiveInfinity, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal WindageInches { get; set; }
        [Range(0.0d, double.PositiveInfinity, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal ElevationInches { get; set; }
        public WindDirection WindDirection { get; set; }

    }
}
