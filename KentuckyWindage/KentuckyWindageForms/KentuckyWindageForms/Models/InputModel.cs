using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KentuckyWindageForms.Attributes;

namespace KentuckyWindageForms.Models
{
    public class InputModel
    {
        [Positive] 
        public decimal TargetSizeInches { get; set; }
        [Positive]
        public decimal TargetSizeMilDots { get; set; }
        [Positive]
        public decimal WindageInches { get; set; }
        [Positive]
        public decimal ElevationInches { get; set; }
        public WindDirection WindDirection { get; set; }

    }
}
